namespace StageSix.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
[Route("Admin")]
public class DashboardController : Controller
{
    [HttpGet("Dashboard")]
    [Route("")]
    public IActionResult Index() => View();
}
