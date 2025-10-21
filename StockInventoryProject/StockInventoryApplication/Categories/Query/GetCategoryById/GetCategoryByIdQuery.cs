using MediatR;
using StockInventoryApplication.Categories.Query.GetCategoryList;

namespace StockInventoryApplication.Categories.Query.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;
