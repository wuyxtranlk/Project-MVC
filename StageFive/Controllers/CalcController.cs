using Microsoft.AspNetCore.Mvc;
using StageFive.Services.Calcs;
using StageFive.Services.Tests;

namespace StageFive.Controllers;

[Route("calc")]
public class CalcController : Controller
{

    public readonly ICalcService _calcService;
    public readonly ITestServices _testServices;

    public CalcController(ICalcService calcService, ITestServices testServices)
    {
        _calcService = calcService;
        _testServices = testServices;
    }

    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.Sum = _calcService.Sum(2, 3);
        ViewBag.Multi = _calcService.Multi(5, 10);
        ViewBag.Message = _testServices.GetMessage();
        ViewBag.Fullname = _testServices.GetFullname("Huy Trần");
        return View();
    }
}



