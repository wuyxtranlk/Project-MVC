using Microsoft.AspNetCore.Authorization;
namespace StageSix.Controllers;

[Route("san-pham")]
[Authorize]
public class ProductController(IProductService pro) : Controller
{
    [Route("danh-sach")]
    [Route("")]
    //[Route("~/")]
    public IActionResult Index() => View(pro.GetProducts());
    [Route("chi-tiet")]
    public IActionResult Details(int id) => View(pro.GetProductById(id));

    [HttpGet("tim-kiem")]
    public IActionResult Search(string search)
    {
        IEnumerable<Product> products = string.IsNullOrEmpty(search) ? pro.GetProducts() : pro.FilterByAnyKeyWord(search);
        return View("Index", products);
    }
}
