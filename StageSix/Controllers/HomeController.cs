using Microsoft.AspNetCore.Mvc;

namespace StageSix.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [Route("index")]
    [Route("")]
    //[Route("~/")]
    public IActionResult Index() => View();
}
