var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

//yeu cau dung routing
app.UseRouting();

#region Convention route

//convention route
//localhost:port/Controller/Action/id
//localhost:port/Home/Index/5
//localhost:port/Home/Index
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//);

//localhost:port/Controller/Action/fullname/gender
//localhost:port/Home/Index1/NguyenVanA/true
//localhost:port/Home/Index1/NguyenVanA/
//localhost:port/Home/Index1/
//localhost:port
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index1}/{fullname?}/{gender?}"
//);
#endregion

#region Attribute route
//dung attribute route
app.MapControllers();
#endregion
app.Run();
