using AutoMapper;
using MediatR;
using StockInventoryApplication.Inventories.Query.GetInventoryList;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Inventories.Query.GetInventoryById;

public class GetInventoryByIdQueryHandler(IInventoryRepository inventoryRepository, IMapper mapper) : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetByIdAsync(request.id, cancellationToken);
        if (inventory == null)
        {
            throw new KeyNotFoundException($"Inventory with ID {request.id} not found.");
        }
        return _mapper.Map<InventoryDto>(inventory);
    }
}
