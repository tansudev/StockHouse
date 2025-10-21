using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using StockInventoryApplication.Common.SoftDelete;
using StockInventoryDomain.Common;

namespace StockInventoryApplication;

public static class DependencyInjectionStock
{
    public static IServiceCollection AddStockApplication(this IServiceCollection services)
    {
        // Register application services, MediatR handlers, etc. here

        // Marker-type yaklaşımıyla assembly’i işaretleyin
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
              Assembly.GetExecutingAssembly()));

        // Some IoC/scan combinations may not wire open-generic handlers for closed generic requests
        // automatically. To ensure MediatR can resolve e.g. SoftDeleteCommand<Category>, register
        // a closed generic mapping for every concrete SoftDeletableAggregate found in the domain assembly.
        var domainAssembly = typeof(SoftDeletableAggregate).Assembly;
        var aggregateTypes = domainAssembly.GetTypes()
            .Where(t => !t.IsAbstract && typeof(SoftDeletableAggregate).IsAssignableFrom(t));

        foreach (var agg in aggregateTypes)
        {
            var requestType = typeof(SoftDeleteCommand<>).MakeGenericType(agg);
            var handlerInterface = typeof(MediatR.IRequestHandler<,>).MakeGenericType(requestType, typeof(SoftDeleteResult));
            var handlerImpl = typeof(SoftDeleteCommandHandler<>).MakeGenericType(agg);

            services.AddScoped(handlerInterface, handlerImpl);
        }

        return services;
    }

}
