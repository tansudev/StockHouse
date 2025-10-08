using System;

namespace StockInventoryService.Endpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/inventory", () => "Inventory Service is running.");
    }
}
