using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Products.Command.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository = productRepository;
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new StockInventoryDomain.Aggregates.Product
        {
            Name = request.Name,
            Description = request.Description,
            Sku = request.Sku,
            CategoryId = request.CategoryId,
            Uom = request.Uom,
            IsActive = request.IsActive,
            Price = request.Price
        };

        await _productRepository.AddAsync(product);

        return Unit.Value;
    }
}
