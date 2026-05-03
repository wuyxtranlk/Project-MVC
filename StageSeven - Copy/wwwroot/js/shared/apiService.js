const apiService = {
    // 1. Cấu hình Header mặc định
    defaultHeaders: {
        'Content-Type': 'application/json; charset=utf-8',
        'Accept': 'application/json, text/plain, */*'
    },

    // 2. Hàm lấy Anti-Forgery Token (hỗ trợ cả form ẩn và thẻ meta)
    getAntiForgeryToken() {
        const el = document.querySelector('input[name="__RequestVerificationToken"]');
        if (el) return el.value;
        const meta = document.querySelector('meta[name="RequestVerificationToken"]');
        return meta ? meta.content : null;
    },

    // 3. Hàm POST
    async post(url, data, { timeoutMs = 30000 } = {}) {
        const controller = new AbortController();
        const timeoutId = timeoutMs > 0 ? setTimeout(() => controller.abort(), timeoutMs) : null;
        try {
            const headers = { ...this.defaultHeaders };
            const token = this.getAntiForgeryToken();
            if (token) headers['RequestVerificationToken'] = token;

            const res = await fetch(url, {
                method: 'POST',
                headers: headers,
                body: JSON.stringify(data),
                signal: controller.signal,
                credentials: 'same-origin' // Gửi kèm Cookie bảo mật
            });

            // Xử lý 204 No Content
            if (res.status === 204) return null; 

            // Tự ném lỗi nếu HTTP Status là 4xx, 5xx
            if (!res.ok) {
                const txt = await res.text();
                const err = new Error(txt || `HTTP ${res.status}`);
                err.status = res.status;
                err.body = txt;
                throw err;
            }

            // Đọc và trả về dữ liệu (JSON hoặc HTML/Text)
            const ct = res.headers.get('content-type') || '';
            if (ct.includes('application/json')) return await res.json();
            if (ct.includes('text/')) return await res.text();
            return null;

        } catch (err) {
            // Hứng TẤT CẢ các lỗi (từ fetch hoặc do ta tự ném ở trên)
            err.url = url; 
            if (err.name === 'AbortError') {
                err.message = 'Request timed out';
                err.isTimeout = true;
            }
            throw err; // Ném ra cho View xử lý hiển thị UI
        } finally {
            // Luôn dọn dẹp bộ đếm thời gian
            if (timeoutId) clearTimeout(timeoutId);
        }
    },

    // 4. Hàm GET
    async get(url, params = null, { timeoutMs = 30000 } = {}) {
        const controller = new AbortController();
        const timeoutId = timeoutMs > 0 ? setTimeout(() => controller.abort(), timeoutMs) : null;

        // Ensure finalUrl is in scope for catch handlers
        let finalUrl = url;
        try {
            // Tự động nối tham số thành Query String
            if (params) {
                const queryString = new URLSearchParams(params).toString();
                finalUrl = `${url}?${queryString}`;
            }

            // GET chỉ cần header Accept, không cần Content-Type
            const headers = { Accept: this.defaultHeaders.Accept };

            const res = await fetch(finalUrl, {
                method: 'GET',
                headers: headers,
                signal: controller.signal,
                credentials: 'same-origin' // Gửi kèm Cookie nếu có cơ chế phân quyền
            });

            if (res.status === 204) return null;

            if (!res.ok) {
                const txt = await res.text();
                const err = new Error(txt || `HTTP ${res.status}`);
                err.status = res.status;
                err.body = txt;
                throw err;
            }

            const ct = res.headers.get('content-type') || '';
            return ct.includes('application/json') ? await res.json() : await res.text();

        } catch (err) {
            err.url = finalUrl; 
            if (err.name === 'AbortError') {
                err.message = 'Request timed out';
                err.isTimeout = true;
            }
            throw err;
        } finally {
            if (timeoutId) clearTimeout(timeoutId);
        }
    }
};

// 5. Xuất module theo chuẩn ES6
export default apiService;
