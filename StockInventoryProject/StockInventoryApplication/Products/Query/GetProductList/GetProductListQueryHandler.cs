using AutoMapper;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Products.Query.GetProductList;

public class GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductListQuery, IReadOnlyList<ProductDto>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }
}
