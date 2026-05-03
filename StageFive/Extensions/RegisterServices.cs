namespace StageFive.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITestServices, TestServices>();
        services.AddScoped<ICalcService, CalcService>();
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IProductService, ProductService>();

        // dùng cho nhiều service có cùng interface nhưng khác implementation, dùng Keyed để phân biệt
        services.AddKeyedScoped<IGeometryServices, CircleService>("Circle");
        services.AddKeyedScoped<IGeometryServices, SquareService>("Square");
        services.AddKeyedScoped<IGeometryServices, RectangleService>("Rectangle");
        return services;
    }
}
