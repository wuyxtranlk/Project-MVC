using Microsoft.AspNetCore.Mvc;

namespace StageFour.Controllers;

[Route("product")]//localhost:port/product
//[Route("")]//localhost:port
public class ProductController1 : Controller
{
    //[Route("")]//localhost:port/product
    //khi dang co nhiu controller dung dau "/" de uu tien chon cai nao
    [Route("/")]//Tuyet doi phai la cai nay=>localhost:port
    [Route("index")]//localhost:port/product/index
    public IActionResult Index() => View();

    [Route("index1/{id?}")]//localhost:port/product/index1/5
    public IActionResult Index1(int? id)
    {
        ViewBag.Id = id;
        return View();
    }

    [Route("index2/{id?}/{name?}")]//localhost:port/product/index2/5/tran
    //localhost:port/product/index2/5/
    //localhost:port/product/index2/
    public IActionResult Index2(int? id, string? name)
    {
        ViewBag.Id = id;
        ViewBag.Name = name;
        return View();
    }

    //dung query string
    //localhost:port/product/index3?id=5&name=tran
    //localhost:port/product/index3?name=tran&id=5
    //localhost:port/product/index3?id=5
    //localhost:port/product/index3
    [Route("index3")]
    public IActionResult Index3(int? id, string? name)
    {
        ViewBag.Id = id;
        ViewBag.Name = name;
        return View();
    }

    //route constraint bẫy lỗi chính xác dữ liệu truyền vào
    [Route("index4/{id:int?}")]//localhost:port/product/index4/5
    public IActionResult Index4(int? id)
    {
        ViewBag.Id = id;
        return View();
    }


    [Route("index5/{id:alpha?}")]//alpha nghia la phai la chuoi tu a den z (hoa,thuong) k dc nhap so
    //[Route("index5/{id:alpha:length(5,10)?}")]//them length de dieu kien k dc ngan hon 5 hay dai hon 10
    //cach khac dung regex
    //[Route("index5/{id:regex(^[[a-zA-Z]]+$)?}")]
    //[Route("index5/{id:regex(^[[a-zA-Z]]{{5,10}}$)?}")]
    public IActionResult Index5(int? id)
    {
        ViewBag.Id = id;
        return View();
    }
}
