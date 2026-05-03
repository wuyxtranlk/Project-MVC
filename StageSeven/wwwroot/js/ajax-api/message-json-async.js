import apiService from '/js/shared/apiService.js';
document.getElementById("btnMessageJsonAsync").addEventListener('click',
	async () => {
		try {
			//c1: dùng cho các bạn yếu và nhanh
			//localhost:xxx/ajaxapi/message-json-async
			// const url = '/ajaxapi/message-json-async'

			//c2: dùng cho các bạn giỏi và hơi phức tạp 1 xíu
			//localhost:xxx/webbanhang/ajaxapi/message-json-async
			// const url = `@Url.Action("message-json-async", "AjaxAPI")`;

			//c3: mạnh nhất, dễ bảo trì, nhưng khó viết code, ko cần controller vì là tên duy nhất
			const url = document.getElementById("btnMessageJsonAsync").dataset.url;
			//const url = document.getElementById("btnMessageJsonAsync").getAttribute("data-url"); cách này vẫn được nhưng không phổ biến bằng getAttribute
			const result = await apiService.get(url);
			document.getElementById('resultJsonAsync').textContent = result.message;
		} catch (error) {
			console.error('Error fetching message:', error);
			document.getElementById('resultJsonAsync').textContent = 'Error fetching message.';
		}
	});