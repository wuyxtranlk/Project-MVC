
namespace StageSix.Controllers;

[Route("upload")]
public class UploadController(IUploadService upl) : Controller
{
    //[HttpGet("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index() => View();

    [HttpPost("upload-files")]
    [ValidateAntiForgeryToken] //SCRF chống tấn công file giả
    [RequestSizeLimit(10L * 1024 * 1024)] //tông kích thước file tải lên (10MB)
    [RequestFormLimits(MultipartBodyLengthLimit = 2L * 1024 * 1024)] //Giới hạn kích thước 1 file là 2MB
    public async Task<IActionResult> UploadFiles(List<IFormFile> files, CancellationToken ct)
    {
        UploadResult result = await upl.UploadFileAsync(files, ct);
        if (!result.IsSuccess)
        {
            TempData["Error"] = result.ErrorMessage;
        }
        else
        {
            TempData["Success"] = $"Successfully uploaded {result.SuccessCount} file(s).";

        }
        return RedirectToAction(nameof(Index));
    }
}
