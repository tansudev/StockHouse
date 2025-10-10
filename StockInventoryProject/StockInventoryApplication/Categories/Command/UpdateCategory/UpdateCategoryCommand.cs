using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Categories.Command.UpdateCategory;

public class UpdateCategoryCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? SortOrder { get; set; }
    public bool? IsActive { get; set; }
    public string? Code { get; set; }
    public Guid? ParentId { get; set; }
}
