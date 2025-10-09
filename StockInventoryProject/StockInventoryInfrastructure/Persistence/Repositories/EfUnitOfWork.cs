using Microsoft.EntityFrameworkCore.Storage;
using StockInventoryDomain.Abstractions;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public sealed class EfUnitOfWork(AppDbContext db) : IUnitOfWork
{
    private readonly AppDbContext _db = db;

    public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken ct = default)
    {
        if (_db.Database.CurrentTransaction is not null)
            return new NoOpUnitOfWorkTransaction();

        IDbContextTransaction? transaction = await _db.Database.BeginTransactionAsync(ct);
        return new EfUnitOfWorkTransaction(transaction);

    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);

    private sealed class EfUnitOfWorkTransaction(IDbContextTransaction inner) : IUnitOfWorkTransaction
    {
        private readonly IDbContextTransaction _inner = inner;
        private bool _completed;
        public bool IsCompleted => _completed;

        public async Task CommitAsync(CancellationToken ct = default)
        {
            if (_completed) return;
            await _inner.CommitAsync(ct);
            _completed = true;
        }

        public async ValueTask DisposeAsync()
        {
            if (!_completed)
            {
                try { await _inner.RollbackAsync(); }
                catch { }
                _completed = true;
            }
            await _inner.DisposeAsync();

        }

        public async Task RollbackAsync(CancellationToken ct = default)
        {
            if (_completed) return;
            await _inner.RollbackAsync(ct);
            _completed = true;
        }
    }

    private sealed class NoOpUnitOfWorkTransaction : IUnitOfWorkTransaction
    {
        public bool IsCompleted => true;

        public Task CommitAsync(CancellationToken ct = default) => Task.CompletedTask;

        public ValueTask DisposeAsync() => ValueTask.CompletedTask;

        public Task RollbackAsync(CancellationToken ct = default) => Task.CompletedTask;
    }
}
