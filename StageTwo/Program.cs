var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
//mặc định tìm kiếm file index.html, default.html, default.htm
app.UseDefaultFiles();
// dùng các file tĩnh như css, js, hình ảnh
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}"
);
app.Run();
