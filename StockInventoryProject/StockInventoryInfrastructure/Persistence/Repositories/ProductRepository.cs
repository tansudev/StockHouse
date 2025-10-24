using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public class ProductRepository : EfRepository<Product>, IProductRepository
{
    private new readonly AppDbContext _db;
    private readonly DbSet<Product> _products;
    public ProductRepository(AppDbContext db) : base(db)
    {
        _db = db;
        _products = db.Set<Product>();
    }
}
