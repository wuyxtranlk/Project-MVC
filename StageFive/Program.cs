using StageFive.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//dùng MVC
// đăng ký dịch vụ(Service vừa tạo để dùng)
builder.Services.AddServices(); // gọi đến phương thức mở rộng để đăng ký dịch vụ vào DI container
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}"

);

app.MapControllers();

app.Run();
