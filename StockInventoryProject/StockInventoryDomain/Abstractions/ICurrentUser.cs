using System;

namespace StockInventoryDomain.Abstractions;

public interface ICurrentUser
{
    public Guid? UserId { get; }
}
