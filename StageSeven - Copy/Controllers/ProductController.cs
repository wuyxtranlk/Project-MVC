using Microsoft.AspNetCore.Mvc;
using StageSeven.Models;
using StageSeven.Services.Products;

namespace StageSeven.Controllers;

[Route("san-pham")]
//[Authorize]
public class ProductController(IProductService PS) : Controller
{
    [Route("danh-sach")]
    [Route("")]
    //[HttpGet("~/")]

    public IActionResult Index() => View(PS.GetProducts());
    [Route("chi-tiet-san-pham")]
    public IActionResult Details(int id) => View(PS.GetProductById(id));
    [HttpGet("tim-kiem")]
    public IActionResult Search(string search)
    {
        IEnumerable<Product> products = string.IsNullOrEmpty(search) ? PS.GetProducts() : PS.FilterByAnyKeyWord(search);
        return View("Index", products);

    }
}