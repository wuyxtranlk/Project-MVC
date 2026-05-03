var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
//app.UseExceptionHandler("/Home/Error");
//app.UseHsts();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StronglyTypeView}/{action=CallTempData}");

app.Run();
