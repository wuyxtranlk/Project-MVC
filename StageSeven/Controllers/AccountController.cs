using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StageSeven.Services.Accounts;


namespace StageSeven.Controllers;

[Route("Account")]
[AllowAnonymous]
public class AccountController(IAccountService acc) : Controller
{
    [Route("Login")]
    [Route("")]
    [HttpGet("~/")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Login() => View();

    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Login(string username, string password)
    {

        if (acc.Login(username, password))
        {
            HttpContext.Session.SetString("Username", username);
            return RedirectToAction("Index", "Product");
        }
        ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
        return View();
    }
    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        TempData["SuccessMessage"] = "Logged out successfully";
        return RedirectToAction(nameof(Login));
    }
    [HttpGet("AccessDenied")]
    public IActionResult AccessDenied() => View("AccessDenied");
}
