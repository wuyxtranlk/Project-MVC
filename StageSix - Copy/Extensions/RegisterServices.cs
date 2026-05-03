namespace StageSix.Extensions;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUploadService, UploadService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }

}
