using Microsoft.AspNetCore.Mvc;

namespace StageFour.Controllers;

[Route("home")]//localhost:port/home
//[Route("")]//localhost:port
public class HomeController : Controller
{
    //dung attribute route
    //[Route("")]//localhost:port/home
    [Route("index")]//localhost:port/home/index
    public IActionResult Index() => View();

    [Route("")]//localhost:port/home
    [Route("index1")]//localhost:port/home/index1
    public IActionResult Index1() => View();



    //convention route
    ////action co tham so id kieu int co the null
    //public IActionResult Index(int? id)
    //{
    //    ViewBag.Id = id;
    //    return View();
    //}

    //public IActionResult Index1(string? fullname, bool? gender)
    //{
    //    ViewBag.Fullname = fullname;
    //    ViewBag.Gender = gender;
    //    return View();
    //}


}
