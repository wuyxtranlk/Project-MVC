using Microsoft.AspNetCore.Mvc;

namespace StageTwo.Controllers;

public class AccountController : Controller
{
    public IActionResult Index() => View("Index");
}
