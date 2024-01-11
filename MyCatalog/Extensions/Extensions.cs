using Microsoft.Extensions.DependencyInjection;
using MyCatalog.Services;

namespace MyCatalog.Extensions;

public static class Extensions
{
    public static IServiceCollection AddApplicationDefaults(this IServiceCollection services)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();
        
        services.AddOutputCache();
        //Add ef core aspire register
        

        services.AddScoped<IProductsRepository, ProductsRepository>();

        return services;
    }
}
