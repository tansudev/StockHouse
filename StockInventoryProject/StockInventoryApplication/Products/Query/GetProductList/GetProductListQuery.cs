using MediatR;

namespace StockInventoryApplication.Products.Query.GetProductList;

public record GetProductListQuery : IRequest<IReadOnlyList<ProductDto>>;
