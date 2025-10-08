using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockInventoryDomain.Aggregates;
namespace StockInventoryInfrastructure.Persistence.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.ProductId).IsRequired();
        builder.Property(i => i.Quantity).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(i => i.IsActive).HasDefaultValue(true);
    }

}
