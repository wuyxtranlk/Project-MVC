namespace StageFive.Controllers;

[Route("geometry")]
public class GeometryController(

    [FromKeyedServices("Circle")] IGeometryServices circleService,
    [FromKeyedServices("Square")] IGeometryServices squareService,
    [FromKeyedServices("Rectangle")] IGeometryServices rectangleService

) : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.CircleArea = circleService.GetArea(new GeometryInput { Radius = 5 });
        ViewBag.SquareArea = squareService.GetArea(new GeometryInput { Side = 4 });
        ViewBag.RectangleArea = rectangleService.GetArea(new GeometryInput { Length = 6, Width = 3 });
        return View();
    }
}
