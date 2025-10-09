using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Categories.Command.DeleteCategory;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _categoryRepository.GetByIdAsync(request.Id, cancellationToken).Result;
        if (category is null)
        {
            throw new Exception("Category not found");
        }
        _categoryRepository.DeleteAsync(category);
        return Task.FromResult(Unit.Value);
    }
}
