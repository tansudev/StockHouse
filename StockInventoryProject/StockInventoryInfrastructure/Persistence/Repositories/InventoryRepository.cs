using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates; // Add this line (adjust namespace as needed)

namespace StockInventoryInfrastructure.Persistence.Repositories;

public class InventoryRepository : EfRepository<Inventory>, IInventoryRepository
{
    private new readonly AppDbContext _db;
    private readonly DbSet<Inventory> _inventories;
    public InventoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
        _inventories = db.Set<Inventory>();
    }
}
