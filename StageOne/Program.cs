//tạo đối tượng để tạo ứng dụng web WebApplication.CreateBuilder(args) chuẩn bị nhiều thứ như config, logging, dependency injection, v.v. cho ứng dụng web của bạn
var builder = WebApplication.CreateBuilder(args);

// tạo web mvc
builder.Services.AddControllersWithViews(); // đăng kí dịch vụ MVC để sử dụng controller và view trong ứng dụng web của bạn

// hông có view thì tạo web api
//builder.Services.AddControllers();

// tạo ra ứng dụng khi đã chuẩn bị xog builder
var app = builder.Build();

#region Endpoint
//sau dòng var app = builder.Build(); 
//nơi này khai báo route, thêm middleware để xử lý request và response ở giữa đường đi khi client gọi đến server hay ngược lại (xác thực, ghi log, chuyển hướng web,...)
// chạy web server,  chạy endpointm...

// đăng kí 1 endpoint bằng MapGet
// 1) http method dùng Get
// 2) đường đãn cụ thẻ là localhost:port/ (dấu "/" nghĩa là trang chủ)
// 3) handler: code xử lý được gọi khi truy cập là "Hello World!"
// code
//app.MapGet("/", () => "Hello World!");
#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}"
);

// web được chạy chính thức
app.Run();
