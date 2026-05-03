
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddServices(); // register app services

//(***) khai báo cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        //nếu đăng nhập không đúng thì quay về trang này
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied"; // trang hiển thị khi user không có quyền truy cập
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.SlidingExpiration = true; // tự động gia hạn cookie nếu user hoạt động
    });
//(***) Phải đăng nhập mới vào được tất cả các controller 
builder.Services.AddAuthorizationBuilder().SetFallbackPolicy(
     new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build()
);
#region Session
// register session infrastructure BEFORE Build()
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
#endregion

var app = builder.Build();

// middleware
app.UseRouting();
//app.UseSession(); // kích hoạt session
app.UseAuthentication(); // kích hoạt authentication 
app.UseAuthorization(); // kich hoạt authorization

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/"
);

//convention route client
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/"
);
//attribute route 
app.MapControllers();
app.Run();
