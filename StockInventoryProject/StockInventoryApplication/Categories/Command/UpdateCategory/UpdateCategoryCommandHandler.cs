using System;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Categories.Command.UpdateCategory;

public class UpdateCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository = repository;
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _repository.GetByIdAsync(request.Id).Result;
        if (category == null)
            throw new Exception("Category not found");

        category.Name = request.Name ?? category.Name;
        category.Description = request.Description ?? category.Description;
        category.SortOrder = request.SortOrder ?? category.SortOrder;
        category.IsActive = request.IsActive ?? category.IsActive;
        category.Code = request.Code ?? category.Code;
        category.ParentId = request.ParentId ?? category.ParentId;
        await _repository.UpdateAsync(category);
        return Unit.Value;
    }
}
