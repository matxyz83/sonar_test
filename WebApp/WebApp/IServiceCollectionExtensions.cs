using WebApp.Services;

namespace WebApp;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddWebAppServices(this IServiceCollection services)
    {

        return services
            .AddScoped<IServiceClass1, ServiceClass1>()
            .AddScoped<IServiceClass2, ServiceClass2>();
    }
}

