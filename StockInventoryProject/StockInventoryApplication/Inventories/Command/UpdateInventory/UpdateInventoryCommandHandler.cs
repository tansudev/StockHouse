using System;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Inventories.Command.UpdateInventory;

public class UpdateInventoryCommandHandler(IInventoryRepository inventoryRepository) : IRequestHandler<UpdateInventoryCommand, Unit>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception("Inventory not found.");

        inventory.ProductId = request.ProductId ?? inventory.ProductId;
        inventory.Quantity = request.Quantity ?? inventory.Quantity;
        inventory.IsActive = request.IsActive ?? inventory.IsActive;

        await _inventoryRepository.UpdateAsync(inventory, cancellationToken);
        return Unit.Value;
    }
}
