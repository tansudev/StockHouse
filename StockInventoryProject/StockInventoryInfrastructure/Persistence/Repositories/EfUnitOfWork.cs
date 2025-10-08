using StockInventoryDomain.Abstractions;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public sealed class EfUnitOfWork(AppDbContext db) : IUnitOfWork
{
    private readonly AppDbContext _db = db;

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);

}
