using Microsoft.AspNetCore.Mvc;
using StageFive.Services.Houses;

namespace StageFive.Controllers;

[Route("house")]
public class HouseController(IHouseService houseService) : Controller
{
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.Area = houseService.Area(5, 10);
        ViewBag.Perimeter = houseService.Perimeter(5, 10);
        return View();
    }
}
