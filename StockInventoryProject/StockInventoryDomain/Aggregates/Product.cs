using System;
using StockInventoryDomain.Common;

namespace StockInventoryDomain.Aggregates;

public class Product : SoftDeletableAggregate
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Sku { get; set; }
    public Guid CategoryId { get; set; }
    public required string Uom { get; set; }
    public bool IsActive { get; set; }
    public decimal Price { get; set; }
}
