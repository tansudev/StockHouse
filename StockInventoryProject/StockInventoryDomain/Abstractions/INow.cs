using System;

namespace StockInventoryDomain.Abstractions;

public interface INow
{
    public DateTime UtcNow { get; }
}
public sealed class SystemNow : INow
{
    public DateTime UtcNow => DateTime.UtcNow;
}