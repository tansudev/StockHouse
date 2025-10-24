
using MediatR;
using StockInventoryApplication.Products.Query.GetProductList;

namespace StockInventoryApplication.Products.Query.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
