using AutoMapper;
using MediatR;
using StockInventoryDomain.Abstractions;

namespace StockInventoryApplication.Inventories.Query.GetInventoryList;

public class GetInventoryListQueryHandler(IInventoryRepository inventoryRepository, IMapper mapper) : IRequestHandler<GetInventoryListQuery, List<InventoryDto>>
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<List<InventoryDto>> Handle(GetInventoryListQuery request, CancellationToken cancellationToken)
    {
        var inventories = await _inventoryRepository.GetAllAsync(cancellationToken);
        var inventoryDtos = _mapper.Map<List<InventoryDto>>(inventories);
        return inventoryDtos;
    }
}
