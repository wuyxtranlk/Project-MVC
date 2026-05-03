using Microsoft.AspNetCore.Mvc;
using StageFive.Services.Products;

namespace StageFive.Controllers;

[Route("product")]
public class ProductController(IProductService productService) : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.Products = productService.GetProducts();
        return View();
    }
    [Route("index1")]
    public IActionResult Index1() => View(productService.GetProducts() ?? null);

    [Route("index2/{id}")]
    public IActionResult Index2(int id) => View(productService.GetProductById(id) ?? null);
}
