using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockInventoryApplication.Category.Query.GetCategoryList;

namespace StockInventoryService.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        // var group = app.MapGroup("/categories").WithTags("Categories");

        app.MapGet("/categories", async ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var query = new GetCategoryListQuery();
            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetCategories")
        .Produces<List<CategoryDto>>(StatusCodes.Status200OK);
    }
}
