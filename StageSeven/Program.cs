using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using StageSeven.Extensions;
using StageSeven.Services.Products;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddServices();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorizationBuilder().SetFallbackPolicy(
     new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build()
);
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
);

app.MapControllers();
app.Run();
