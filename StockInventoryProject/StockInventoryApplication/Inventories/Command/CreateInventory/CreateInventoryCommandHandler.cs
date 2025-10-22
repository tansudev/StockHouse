using MediatR;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates;

namespace StockInventoryApplication.Inventories.Command.CreateInventory;

public class CreateInventoryCommandQuery(IInventoryRepository inventoryRepository) : IRequestHandler<CreateInventoryCommand, Unit>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    public async Task<Unit> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = new Inventory
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            IsActive = request.IsActive
        };

        await _inventoryRepository.AddAsync(inventory, cancellationToken);
        return Unit.Value;
    }
}
