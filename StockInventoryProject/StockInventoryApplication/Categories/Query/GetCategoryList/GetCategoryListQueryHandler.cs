using AutoMapper;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Categories.Query.GetCategoryList;

public class GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}
