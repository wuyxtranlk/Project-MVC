using Microsoft.AspNetCore.Mvc;

namespace StageThree.Controllers;

public class ProductController : Controller
{
    public IActionResult Index() => View("Index");
}
