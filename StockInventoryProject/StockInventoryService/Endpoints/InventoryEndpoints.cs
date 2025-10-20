using System;
using StockInventoryDomain.Aggregates;
using StockInventoryService.Extensions;

namespace StockInventoryService.Endpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/inventory", () => "Inventory Service is running.");
        app.MapSoftDeleteFor<Inventory>("/inventories");
    }
}
