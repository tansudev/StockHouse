using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Inventories.Command.CreateInventory;

public class CreateInventoryCommand : ICommand<Unit>
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public bool IsActive { get; set; }

}
