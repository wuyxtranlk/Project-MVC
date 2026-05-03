namespace StageSix.Services.Upload;

public class UploadService(IWebHostEnvironment env) : IUploadService
{
  private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".gif" ];

  public async Task<UploadResult> UploadFileAsync(List<IFormFile> files, CancellationToken ct)
  {
    if(files == null || files.Count == 0)
    {
      return new UploadResult(0, "vui lòng chọn ít nhất 1 file", false);
    }

    //nhờ environment để lấy đường dẫn tuyệt đối đến thư mục wwwroot/uploads
    string targetPath = Path.Combine(env.WebRootPath, "uploads");

    //nếu thư mục updloads chưa tồn tại thì tạo mới
    if(!Directory.Exists(targetPath))
    {
      Directory.CreateDirectory(targetPath);
    }

    int successCount = 0;
    try
    {
      foreach(IFormFile file in files)
      {
        //lỗi nếu tắt web hay rớt mạng
        ct.ThrowIfCancellationRequested();
        string ext = Path.GetExtension(file.FileName).ToLowerInvariant();

        if(!AllowedExtensions.Contains(ext))
          continue;

        string newFileName = $"{Guid.NewGuid():N}{ext}";
        string filePath = Path.Combine(targetPath, newFileName);

        await using FileStream stream = new(filePath, FileMode.Create);
        await file.CopyToAsync(stream, ct);
        successCount++;
      }
      return new UploadResult(successCount, string.Empty, true);
    }
    catch(OperationCanceledException)
    {
      return new UploadResult(0, "Upload canceled", false);
    }
    catch(Exception ex)
    {
      return new UploadResult(0, $"Error: {ex.Message}", false);
    }

  }
}