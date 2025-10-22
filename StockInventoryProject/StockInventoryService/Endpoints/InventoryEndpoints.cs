using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockInventoryApplication.Inventories.Command.CreateInventory;
using StockInventoryApplication.Inventories.Command.DeleteInventory;
using StockInventoryApplication.Inventories.Command.UpdateInventory;
using StockInventoryApplication.Inventories.Query.GetInventoryById;
using StockInventoryApplication.Inventories.Query.GetInventoryList;
using StockInventoryDomain.Aggregates;
using StockInventoryService.Extensions;

namespace StockInventoryService.Endpoints;

public static class InventoryEndpoints
{
    public static void MapInventoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/inventories", async ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetInventoryListQuery();
            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        app.MapGet("/inventories/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, CancellationToken cancellationToken) =>
        {
            var query = new GetInventoryByIdQuery(id);
            var result = await mediator.Send(query, cancellationToken);
            return result != null ? Results.Ok(result) : Results.NotFound();
        });
        app.MapPost("/inventories", async ([FromServices] IMediator mediator, [FromBody] CreateInventoryCommand command, CancellationToken cancellationToken) =>
        {
            await mediator.Send(command, cancellationToken);
            return Results.Ok();
        });
        app.MapPut("/inventories/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, [FromBody] UpdateInventoryCommand command, CancellationToken cancellationToken) =>
        {
            command.Id = id;
            return Results.Ok();
        });
        app.MapDelete("/inventories/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, CancellationToken cancellationToken) =>
        {
            var command = new DeleteInventoryCommand(id);
            await mediator.Send(command, cancellationToken);
            return Results.Ok();
        });
        app.MapSoftDeleteFor<Inventory>("/inventories/soft");
    }
}
