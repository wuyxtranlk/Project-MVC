using Microsoft.AspNetCore.Mvc;

namespace StageOne.Controllers;
// controller là người tiếp nhận yêu cầu từ User
public class AboutController : Controller
{
    // action: phương thức xử lý mặc định khi user truy cập vào controller này.
    // ví dụ: khi user gõ localhost:port/about/index thì sẽ gọi đến action này
    // localhost:port/controller/action
    public IActionResult Index() => View("Index");

    public IActionResult Contact() => View("PersonContact");
}
