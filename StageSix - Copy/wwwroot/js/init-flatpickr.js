flatpickr("#dob", {
    dateFormat: "Y-m-d",
    maxDate: "today",
    altInput: true,
    altFormat: "d/m/Y",
    locale: "vn"
});

// cho start date and end date
const sharedConfig =
{
    dateFormat: "Y-m-d",
    altInput: true,
    altFormat: "d/m/Y",
    locale: "vn",
    allowInput: true,
    maxDate: new Date().fp_incr(30) // chọn 1 tháng từ ngày hiện tại
};

// khởi tạo enddate trước để startdate callback có thể cập nhật enddate
const endpicker = flatpickr("#enddate", { ...sharedConfig });

//khởi tạo startdate với callback cập nhật enddate
const startpicker = flatpickr("#startdate", {
    ...sharedConfig, onChange: function (selectedDates) {
        // nếu không có ngày nào được chọn, không làm gì    
        if (selectedDates.length === 0) return; {
            // lấy ngày đưuọc chọn đầu tiên(chỉ có 1 ngày được chọn) 
            const start = selectedDates[0];
            const nextDay = new Date(start).fp_incr(1); // ngày tiếp theo
            endpicker.set("minDate", nextDay); // cập nhật minDate của endpicker 
            endpicker.setDate(nextDay, true); // tự động chọn ngày tiếp theo cho enddate
        }
    }
});