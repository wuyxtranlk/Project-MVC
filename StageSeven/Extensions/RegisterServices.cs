using StageSeven.Services.Accounts;
using StageSeven.Services.Products;

namespace StageSeven.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}