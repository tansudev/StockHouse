
using AutoMapper;
using MediatR;
using StockInventoryApplication.Products.Query.GetProductList;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Products.Query.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception($"Product with ID {request.Id} not found.");
        return _mapper.Map<ProductDto>(product);
    }
}
