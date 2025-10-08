
using Microsoft.EntityFrameworkCore;
using StockInventoryDomain.Abstractions;
using StockInventoryDomain.Aggregates;

namespace StockInventoryInfrastructure.Persistence.Repositories;

public class CategoryRepository : EfRepository<Category>, ICategoryRepository
{
    private new readonly AppDbContext _db;
    private readonly DbSet<Category> _categories;
    public CategoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
        _categories = db.Set<Category>();
    }
}
