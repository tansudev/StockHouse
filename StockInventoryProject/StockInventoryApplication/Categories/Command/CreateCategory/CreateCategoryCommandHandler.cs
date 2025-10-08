using MediatR;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates;

namespace StockInventoryApplication.Categories.Command.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        var category = new Category
        {
            Name = request.Name,
            Description = request.Description,
            SortOrder = request.SortOrder,
            IsActive = true,
            Code = request.Code,
            ParentId = request.ParentId ?? Guid.Empty,
        };

        await _categoryRepository.AddAsync(category, cancellationToken);
        return Unit.Value;
    }
}
