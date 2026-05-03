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
    [HttpGet("~/")]

    public IActionResult Index() => View(PS.GetProducts());
    [Route("chi-tiet-san-pham")]
    public IActionResult Details(int id) => View(PS.GetProductById(id));
    [HttpGet("sua-san-pham")]
    public IActionResult Edit(int id)
    {
        var product = PS.GetProductById(id);
        return product == null ? NotFound() : View(product);
    }
    [HttpPost("sua-san-pham")]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            PS.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }
    [HttpGet("xoa-san-pham")]
    public IActionResult Delete(int id)
    {
        var product = PS.GetProductById(id);
        return product == null ? NotFound() : View(product);
    }
    [HttpPost("xoa-san-pham")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = PS.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        PS.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("tim-kiem")]
    public IActionResult Search(string search)
    {
        IEnumerable<Product> products = string.IsNullOrEmpty(search) ? PS.GetProducts() : PS.FilterByAnyKeyWord(search);
        return View("Index", products);
    }
    [HttpGet("auto-complete", Name = "AutoComplete")]
    public IActionResult AutoComplete(string term)
    {
        var find = PS.GetProducts()
            .Where(p => p.Name?.Contains(term, StringComparison.OrdinalIgnoreCase) == true)
            .Select(p => p.Name).ToList()
            .Distinct();
        return Json(find);
    }
}