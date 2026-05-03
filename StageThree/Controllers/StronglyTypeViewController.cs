using Microsoft.AspNetCore.Mvc;
using StageThree.Models;

namespace StageThree.Controllers;

public class StronglyTypeViewController : Controller
{
    // có hỗ trợ intellisense khi sử dụng strongly type view
    public IActionResult Index()
    {
        // ViewData tương tự viewbag nhưng dùng theo key, value
        ViewData["Title"] = "Strongly Type View";
        ViewData["Price"] = 30.5;
        ViewData["Quantity"] = 100;
        // truyền 1 object
        Product pro = new()
        {
            Id = 1,
            Name = "Iphone 14 Pro Max",
            Price = 30000000,
            Quantity = 100,
            Status = true,
            Mfg = DateTime.Now,
            Photo = "hinh1.gif"

        };
        // return View(pro); // dùng strongly type view (view nhận vào 1 model)
        return View("Index", pro); // dùng strongly type view (view nhận vào 1 model)
    }
    public IActionResult ListProduct()
    {
        List<Product> list =
            [
               new Product {
                    Id = 2,
                    Name = "Product 3",
                    Photo = "hinh3.gif",
                    Mfg = DateTime.Now,
                    Status = true,
                    Price = 29.99,
                    Quantity = 100,
               },
               new Product
               {
                    Id = 3,
                    Name = "Product 4",
                    Photo = "hinh2.gif",
                    Mfg = DateTime.Now,
                    Status = true,
                    Price = 39.99,
                    Quantity = 100,
               }
            ];
        return View(list);
    }
    public IActionResult CallTempData()
    {
        // TempData tương tự ViewData nhưng chỉ tồn tại trong 1 request, sau khi đã đọc TempData sẽ bị xóa đi, thường dùng cho chuyển hướng ví dụ dăng ký thành công, đăng ký thất bại, v.v....
        TempData["Title"] = "Call Temp Data";
        //tưởng gọi view là ListProduct.cshtml
        //nhưng thật ra gọi action là ListProduct, sau đó ListProduct sẽ gọi view ListProduct.cshtml
        return RedirectToAction("ListProduct");
    }
}
