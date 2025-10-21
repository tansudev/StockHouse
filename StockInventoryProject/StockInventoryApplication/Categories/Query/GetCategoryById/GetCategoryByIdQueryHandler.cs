using AutoMapper;
using MediatR;
using StockInventoryApplication.Categories.Query.GetCategoryList;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates;

namespace StockInventoryApplication.Categories.Query.GetCategoryById;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null) return null;
        return _mapper.Map<CategoryDto>(category);
    }
}
