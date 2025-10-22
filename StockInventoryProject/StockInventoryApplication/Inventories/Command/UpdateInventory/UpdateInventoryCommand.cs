using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Inventories.Command.UpdateInventory;

public class UpdateInventoryCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
    public Guid? ProductId { get; set; }
    public decimal? Quantity { get; set; }
    public bool? IsActive { get; set; }
}
