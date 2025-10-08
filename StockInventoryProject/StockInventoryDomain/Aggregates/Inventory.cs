using System;

namespace StockInventoryDomain.Aggregates;

public class Inventory : BaseAggregate
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public bool IsActive { get; set; }
}

