using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Categories.Command.DeleteCategory;

public class DeleteCategoryCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
}
