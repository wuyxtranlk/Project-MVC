using Microsoft.AspNetCore.Mvc;
using StageSeven.ViewModels;

namespace StageSeven.Controllers;

[Route("AjaxPost")]
public class AjaxPostController : Controller
{
    //[HttpGet("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index() => View();

    [HttpPost("get-name")]
    public async Task<IActionResult> GetName([FromBody] string name) => await Task.FromResult(Json(new { fullname = $"Hello, {name}" }));

    [HttpPost("get-person", Name = "GetPerson")]
    public IActionResult GetPerson([FromBody] PersonVM person)
    {
        if (person is null)
            return BadRequest("Person data is required");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        //thường dùng cho MVC
        //thường dùng cho web API, vì nó trả về trạng thái http, còn json thì chỉ là dữ liệu
        return Ok(new { fullname = person.Name, age = person.Age });
    }
}
