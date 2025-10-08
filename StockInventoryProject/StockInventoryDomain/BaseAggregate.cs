
namespace StockInventoryDomain;

public class BaseAggregate
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
