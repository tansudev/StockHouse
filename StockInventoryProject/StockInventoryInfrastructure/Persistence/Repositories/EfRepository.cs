using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StockInventoryDomain;
using StockInventoryDomain.Abstractions;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public class EfRepository<T>(AppDbContext db) : IRepository<T> where T : BaseAggregate
{
    protected readonly AppDbContext _db = db;
    protected readonly DbSet<T> _set = db.Set<T>();

    public Task AddAsync(T entity, CancellationToken ct = default)
    {
        _set.Add(entity);
        return Task.CompletedTask;
    }

    public virtual Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        _set.AddRange(entities);
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync(T entity, CancellationToken ct = default)
    {
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    public virtual Task<List<T>> GetAllAsync(CancellationToken ct = default) => _set.AsNoTracking().ToListAsync(cancellationToken: ct);

    public virtual Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default) => _set.AsNoTracking().Where(predicate).ToListAsync(ct);

    public virtual Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default) => _set.FindAsync([id], ct).AsTask();

    public virtual Task UpdateAsync(T entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        return Task.CompletedTask;
    }
}
