using Microsoft.AspNetCore.Mvc;
using StageThree.Models;

namespace StageThree.Controllers;

public class ReviewViewBagController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Message = "Hello,ViewBag!";
        ViewBag.Id = 1;
        ViewBag.Name = "Product 1";
        ViewBag.Price = 9.99;
        ViewBag.Quantity = 100;
        ViewBag.Status = true;
        ViewBag.Mfg = DateTime.Now;
        ViewBag.Photo = "hinh1.gif";
        ViewBag.Width = 50;
        ViewBag.Array = new[] { "item 1", "item 2", "item 3" };
        ViewBag.AnonymousObject = new { Id = 1, Name = "Product 1", Price = 9.99 };
        return View("Index");
    }

    public IActionResult ProductAndListProduct()
    {
        // viewbag chứa 1 đối tượng 
        ViewBag.Product = new Product()
        {
            Id = 2,
            Name = "Product 2",
            Photo = "hinh2.gif",
            Mfg = DateTime.Now,
            Status = true,
            Price = 19.99,
            Quantity = 100,
        };
        ViewBag.ListProduct = new List<Product>()
        {
            new()
            {
                Id = 3,
                Name = "Product 3",
                Photo = "hinh3.gif",
                Mfg = DateTime.Now,
                Status = true,
                Price = 29.99,
                Quantity = 100,
            },
            new()
            {
                Id = 4,
                Name = "Product 4",
                Photo = "hinh3.gif",
                Mfg = DateTime.Now,
                Status = true,
                Price = 39.99,
                Quantity = 100,
            },
        };
        return View("ProductAndListProduct");
    }
}
