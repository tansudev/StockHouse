using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Inventories.Command.DeleteInventory;

public class DeleteInventoryCommandHandler(IInventoryRepository inventoryRepository) : IRequestHandler<DeleteInventoryCommand, Unit>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

    public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(request.id, cancellationToken);
        if (inventory == null) throw new Exception("Inventory not found.");

        await _inventoryRepository.DeleteAsync(inventory, cancellationToken);
        return Unit.Value;
    }
}
