using Microsoft.AspNetCore.Mvc;
using StageSeven.ViewModels;

namespace StageSeven.Controllers;

[Route("ajaxapi")]
public class AjaxAPIController : Controller
{
    [Route("")]
    [Route("index")]
    //[HttpGet("~/")]
    public IActionResult Index() => View();

    //Thuộc tính Name thường trùng với tên phương thức(Action) nhưng có khác nếu muốn
    [HttpGet("message-json-async", Name = "MessageJsonAsync")]
    public IActionResult MessageJsonAsync()
    => Json(new { message = "Ajax: Hello World Json Async!" });

    [HttpGet("get-name-query", Name = "GetNameQuery")]
    public IActionResult GetNameQuery(string name) => Json(new { fullname = $"Hello, {name}" });


    [HttpPost("get-person")]
    public IActionResult GetPerson([FromBody] PersonVM person)
    => person is null
            ? BadRequest("Person data is required")
            : !ModelState.IsValid ? BadRequest(ModelState) : Ok(new { fullname = person.Name, age = person.Age });

}
