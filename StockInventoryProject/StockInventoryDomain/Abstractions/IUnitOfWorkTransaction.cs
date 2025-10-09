namespace StockInventoryDomain.Abstractions;

public interface IUnitOfWorkTransaction : IAsyncDisposable
{
    bool IsCompleted { get; }
    Task CommitAsync(CancellationToken ct = default);
    Task RollbackAsync(CancellationToken ct = default);
}
