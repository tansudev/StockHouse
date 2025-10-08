using System;

namespace StockInventoryDomain.Aggregates;

public class Category : BaseAggregate
{
    public Guid ParentId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Code { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
