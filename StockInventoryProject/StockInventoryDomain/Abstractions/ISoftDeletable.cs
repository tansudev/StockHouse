
namespace StockInventoryDomain.Abstractions;

public interface ISoftDeletable
{
    bool IsDeleted { get; }
    void MarkAsDeleted(Guid? UserId, DateTime now);
}
