
namespace StockInventoryDomain;

public class BaseAggregate
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}
