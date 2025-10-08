using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockInventoryApplication.Category.Query.GetCategoryList;

namespace StockInventoryService.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", async ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetCategoryListQuery();
            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        })
        .Produces<List<CategoryDto>>(StatusCodes.Status200OK);
    }
}
