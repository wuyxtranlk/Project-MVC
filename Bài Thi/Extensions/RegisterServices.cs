using Bài_Thi.Services.Products;

namespace Bài_Thi.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}