using MediatR;
using StockInventoryApplication.Inventories.Query.GetInventoryList;

namespace StockInventoryApplication.Inventories.Query.GetInventoryById;

public record GetInventoryByIdQuery(Guid id) : IRequest<InventoryDto>;