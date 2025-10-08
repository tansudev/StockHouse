using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Aggregates;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public class ProductRepository : EfRepository<Product>
{
    private new readonly AppDbContext _db;
    private readonly DbSet<Product> _products;
    public ProductRepository(AppDbContext db) : base(db)
    {
        _db = db;
        _products = db.Set<Product>();
    }
}
