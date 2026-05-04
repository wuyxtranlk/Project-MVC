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

    public IActionResult Index()
    {
        if (!IsLoggedIn())
        {
            return RedirectToAction("Login", "Account");
        }
        var listProducts = PS.GetProducts();
        return View(listProducts);
    }
    [Route("chi-tiet-san-pham")]
    public IActionResult Details(int id) => View(PS.GetProductById(id));
    private bool IsLoggedIn()
    {
        var user = HttpContext.Session.GetString("Username");
        return !string.IsNullOrEmpty(user) && user == "sa";
    }
    public IActionResult Add() => !IsLoggedIn() ? RedirectToAction("Login", "Account") : View();

    [HttpPost]
    public IActionResult Add(Product addProduct)
    {
        if (!IsLoggedIn()) return RedirectToAction("Login", "Account");
        if (ModelState.IsValid)
        {
            PS.AddProduct(addProduct);
            return RedirectToAction("Index");
        }
        return View(addProduct);
    }
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
        if (!IsLoggedIn()) return RedirectToAction("Login", "Account");

        PS.DeleteProduct(id);

        return RedirectToAction("Index");
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