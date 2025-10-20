using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockInventoryApplication.Common.SoftDelete;
using StockInventoryDomain.Common;

namespace StockInventoryService.Extensions;

public static class SoftDeleteEndpointExtensions
{
    public static IEndpointRouteBuilder MapSoftDeleteFor<TAggregate>(this IEndpointRouteBuilder app, string routeBase) where TAggregate : SoftDeletableAggregate
    {
        app.MapDelete($"{routeBase}/{{id:guid}}", async (Guid id, [FromServices] IMediator mediator, CancellationToken ct) =>
        {
            var command = new SoftDeleteCommand<TAggregate>([id]);
            var result = await mediator.Send(command, ct);

            return Results.Ok(new SoftDeleteResult(result.Effected, result.NotFound, result.AlreadyDeleted));
        });

        return app;
    }

}
