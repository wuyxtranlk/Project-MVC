
using Microsoft.AspNetCore.Mvc;
using StageFive.Services.Tests;
namespace StageFive.Controllers;

[Route("test")]//localhost:xxxx/test
[Route("")]
public class TestController : Controller
{
    //DI Dependency Injection
    public readonly ITestServices _testServices;
    public TestController(ITestServices testServices) => _testServices = testServices;
    [Route("")]//trong đây nếu có nhiều action thì action mặc định là index
    [Route("index")]//localhost:xxxx/test/index gõ đầy đủ cũng được
    public IActionResult Index()
    {
        ViewBag.Message = _testServices.GetMessage();
        return View("Index");
    }
    [Route("index1/{fullname?}")]
    public IActionResult Index1(string? fullname)
    {
        ViewBag.Fullname = _testServices.GetFullname(fullname ?? "");
        return View();
    }
    [Route("index2")]
    public IActionResult Index2(string? fullname)
    {
        ViewBag.Fullname = _testServices.GetFullname("C2409G1");
        ViewBag.Messages = _testServices.GetMessage();
        return View();
    }

}
