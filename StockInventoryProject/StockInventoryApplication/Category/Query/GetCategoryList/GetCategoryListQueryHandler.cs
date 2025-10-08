using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Category.Query.GetCategoryList;

public class GetCategoryListQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return [.. categories.Select(c => new CategoryDto
        {
            ParentId = c.ParentId,
            Name = c.Name,
            Description = c.Description,
            Code = c.Code,
            SortOrder = c.SortOrder,
            IsActive = c.IsActive
        })];
    }
}
