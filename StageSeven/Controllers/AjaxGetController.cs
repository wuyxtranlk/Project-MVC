using Microsoft.AspNetCore.Mvc;

namespace StageSeven.Controllers;

[Route("Ajaxget")]
public class AjaxGetController : Controller
{
    //[HttpGet("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index() => View();

    [HttpGet("message")]
    public IActionResult Message() => Content("Ajax: Hello World!");

    [HttpGet("message-json")]
    public IActionResult MessageJson()
        => Json(new { message = "Ajax: Hello World!" });
    // new JsonResult(new { Message = "Ajax: Hello World!" }) (code cũ không khuyến khích dùng); 

    [HttpGet("message-json-async")]
    public async Task<IActionResult> MessageJsonAsync()
        => await Task.FromResult(Json(new { message = "Ajax: Hello World Json Async!" }));
    //truyền theo route
    [HttpGet("get-name/{name}")]
    public async Task<IActionResult> GetName(string name) => await Task.FromResult(Json(new { fullname = $"Hello, {name}" }));
    // truyền theo query string localhost:port/Ajaxget/get-name-query?name=yourname
    [HttpGet("get-name-query")]
    public async Task<IActionResult> GetNameQuery(string name) => await Task.FromResult(Json(new { fullname = $"Hello, {name}" }));
}
