using System;
using StockInventoryDomain.Aggregates;

namespace StockInventoryDomain.Abstractions;

public interface IInventoryRepository : IRepository<Inventory>
{

}
