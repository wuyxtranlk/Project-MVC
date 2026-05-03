using StageSeven.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddServices();
var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
);

app.UseRouting();

app.Run();
