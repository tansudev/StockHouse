using System;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Products.Command.DeleteProduct;

public class DeleteProductCommandQuery(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            throw new Exception("Product not found");
        }
        await _productRepository.DeleteAsync(product, cancellationToken);
        return Unit.Value;
    }
}
