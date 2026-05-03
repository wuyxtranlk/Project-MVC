using Microsoft.AspNetCore.Mvc;

namespace StageTwo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();// return View("Index"); cái index này là tên file Index.cshtml
    public IActionResult About() => View("About");
    public IActionResult Contact() => View("~/Views/Shared/Contact.cshtml");
}
