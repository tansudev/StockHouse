using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository = productRepository;
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new Exception($"Product with ID {request.Id} not found.");
        }

        product.Name = request.Name ?? product.Name;
        product.Description = request.Description ?? product.Description;
        product.Sku = request.Sku ?? product.Sku;
        product.CategoryId = request.CategoryId ?? product.CategoryId;
        product.Uom = request.Uom ?? product.Uom;
        product.IsActive = request.IsActive ?? product.IsActive;
        product.Price = request.Price ?? product.Price;

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
