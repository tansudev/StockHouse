using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace StockInventoryApplication;

public static class DependencyInjectionStock
{
    public static IServiceCollection AddStockApplication(this IServiceCollection services)
    {
        // Register application services, MediatR handlers, etc. here

        // Marker-type yaklaşımıyla assembly’i işaretleyin
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

}
