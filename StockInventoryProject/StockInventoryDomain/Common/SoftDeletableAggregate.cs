using StockInventoryDomain.Abstractions;

namespace StockInventoryDomain.Common;

public abstract class SoftDeletableAggregate : BaseAggregate, IAggregateRoot, ISoftDeletable
{
    public void MarkAsDeleted(Guid? UserId, DateTime now)
    {
        if (!IsDeleted)
        {
            IsDeleted = true;
            UpdatedBy = UserId;
            UpdatedTime = now;
        }
    }
}
