using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Inventories.Command.DeleteInventory;

public record DeleteInventoryCommand(Guid id) : ICommand<Unit>;
