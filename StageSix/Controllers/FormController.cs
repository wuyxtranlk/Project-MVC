

using StageSix.ViewModels.Product;

namespace StageSix.Controllers;

[Route("Form")]
public class FormController : Controller
{
    [Route("index")]
    [Route("")]
    //[HttpGet("~/")]
    public IActionResult Index() => View();

    [HttpGet("show-name")]
    public IActionResult ShowName(string fullname) => View(model: fullname);
    [HttpGet("show-name-and-quantity")]
    public IActionResult ShowNameAndQuantity(string fullname, int quantity)
    {
        ViewBag.FullName = fullname;
        ViewBag.Quantity = quantity;
        return View();
    }
    [HttpGet("show-name-and-quantity-by-request-query")]
    public IActionResult ShowNameAndQuantityByRequestQuery()
    {
        //Request.Query luôn trả về chuỗi
        ViewBag.FullName = Request.Query["fullname"];
        ViewBag.Quantity = int.Parse(Request.Query["quantity"].ToString());
        return View("ShowNameAndQuantity");
    }
    [HttpPost("show-name-and-quantity-by-request-form")]
    public IActionResult ShowNameAndQuantityByRequestForm()
    {
        //Request.Form luôn trả về chuỗi
        ViewBag.FullName = Request.Query["fullname"];
        ViewBag.Quantity = int.Parse(Request.Query["quantity"].ToString());
        return View("ShowNameAndQuantity");
    }
    [HttpPost("show-product")]
    public IActionResult ShowProduct(Product pro) => View(pro);

    [HttpPost("show-product-by-viewmodel")]
    public IActionResult ShowProductVM(ProductViewModel pro) => View(pro);
    [HttpPost("show-hobbies")]
    //public IActionResult ShowHobbies(string[] hobbies)
    //public IActionResult ShowHobbies(iFormCollection form)
    //do bên cshtml name trùng tên nên trong asp.net core sẽ tự động map vào 1 mảng string, nếu muốn lấy bằng form thì phải đổi tên khác nhau
    public IActionResult ShowHobbies(List<string> hobbies)
    {
        ViewBag.Hobbies = hobbies;
        return View();
    }
    [HttpPost("show-emails")]
    public IActionResult ShowEmails(string[] emails)
    {
        ViewBag.Emails = emails;
        return View();
    }
    [HttpPost("show-date")]
    public IActionResult ShowDate(string dob)
    {
        string[] formats = ["dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd"];
        CultureInfo vi = new("vi-VN");
        bool success =
            DateTime.TryParseExact(dob, formats, vi, DateTimeStyles.None, out DateTime parsed)
            ||
            DateTime.TryParseExact(dob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed);
        if (!success)
        {
            ViewBag.Error = "Invalid date format. Please use dd/MM/yyyy, MM/dd/yyyy, or yyyy-MM-dd.";
            return View();
        }
        else
        {
            ViewBag.Dob = parsed;
            return View();
        }
    }
}
