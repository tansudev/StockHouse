using System;
using StockInventoryDomain.Common;

namespace StockInventoryDomain.Aggregates;

public class Inventory : SoftDeletableAggregate
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public bool IsActive { get; set; }
}

