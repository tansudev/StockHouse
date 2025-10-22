using MediatR;

namespace StockInventoryApplication.Inventories.Query.GetInventoryList;

public record GetInventoryListQuery : IRequest<List<InventoryDto>>;
