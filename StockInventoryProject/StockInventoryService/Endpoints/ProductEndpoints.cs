using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockInventoryApplication.Products.Command.CreateProduct;
using StockInventoryApplication.Products.Command.DeleteProduct;
using StockInventoryApplication.Products.Command.UpdateProduct;
using StockInventoryApplication.Products.Query.GetProductById;
using StockInventoryApplication.Products.Query.GetProductList;
using StockInventoryDomain.Aggregates;
using StockInventoryService.Extensions;

namespace StockInventoryService.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async ([FromServices] IMediator mediator, [FromBody] CreateProductCommand command, CancellationToken cancellationToken) =>
        {
            await mediator.Send(command, cancellationToken);
            return Results.Ok();
        });
        app.MapDelete("/products/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, CancellationToken cancellationToken) =>
        {
            var command = new DeleteProductCommand(id);
            await mediator.Send(command, cancellationToken);
            return Results.Ok();
        });
        app.MapPut("/products/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken) =>
        {
            command.Id = id;
            await mediator.Send(command, cancellationToken);
            return Results.Ok();
        });
        app.MapGet("/products", async ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetProductListQuery();
            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        });
        app.MapGet("/products/{id:guid}", async ([FromServices] IMediator mediator, [FromRoute] Guid id, CancellationToken cancellationToken) =>
        {
            var query = new GetProductByIdQuery(id);
            var result = await mediator.Send(query, cancellationToken);
            return result != null ? Results.Ok(result) : Results.NotFound();
        });
        app.MapSoftDeleteFor<Product>("/products/soft");
    }
}
