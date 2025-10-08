using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Categories.Command.CreateCategory;

public class CreateCategoryCommand : ICommand
{
    public Guid? ParentId { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}
