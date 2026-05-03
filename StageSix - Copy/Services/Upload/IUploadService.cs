
namespace StageSix.Services;

public interface IUploadService
{
  //dùng task để xử lý bất đồng bộ, tránh làm treo UI khi upload file lớn
  Task<UploadResult> UploadFileAsync(List<IFormFile> files, CancellationToken ct);
}
