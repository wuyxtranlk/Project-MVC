namespace StageSix.Controllers;

[Route("Account")]
[AllowAnonymous]
public class AccountController(IAccountService acc) : Controller
{
    [Route("Login")]
    [Route("")]
    //[HttpGet("~/")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Login() => View();

    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (acc.Login(username, password))
        {
            //code cho session
            //TempData["SuccessMessage"] = "Login successful";
            //HttpContext.Session.SetString("Username", username);
            //return RedirectToAction(nameof(Login));

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,
                    username.Equals("admin", StringComparison.OrdinalIgnoreCase) ? "Admin" : "User"
                ) // thêm claim role nếu cần phân quyền
            };
            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            TempData["SuccessMessage"] = "Login successful";
            return RedirectToAction(nameof(Login));
        }
        ViewBag.ErrorMessage = "Invalid username or password";
        return View();
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {
        if (User?.Identity?.IsAuthenticated == true)
        {
            TempData["ErrorMessage"] = "You are already logged in";
            return RedirectToAction(nameof(Login));
        }
        return View();
    }
    [HttpPost("Register")]
    [ValidateAntiForgeryToken]
    public IActionResult Register(string username, string password)
    {
        if (User?.Identity?.IsAuthenticated == true)
        {
            TempData["ErrorMessage"] = "You are already logged in";
            return RedirectToAction(nameof(Login));
        }

        string result = acc.Register(username, password);
        if (result.Contains("success"))
        {
            TempData["SuccessMessage"] = "Registration successful! Please log in";
            return RedirectToAction(nameof(Login));
        }
        ViewBag.ErrorMessage = result;
        return View();
    }
    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        //HttpContext.Session.Remove("Username"); // xóa thông tin đăng nhập của user khỏi session
        //HttpContext.Session.Clear(); // xóa tất cả thông tin trong session

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // xóa cookie đăng nhập
        TempData["SuccessMessage"] = "Logged out successfully";
        return RedirectToAction(nameof(Login));
    }
    [HttpGet("AccessDenied")]
    public IActionResult AccessDenied() => View("AccessDenied");
}
