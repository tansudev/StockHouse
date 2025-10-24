using MediatR;
using StockInventoryApplication.Abstractions.Messaging;

namespace StockInventoryApplication.Products.Command.UpdateProduct;

public class UpdateProductCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Sku { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Uom { get; set; }
    public bool? IsActive { get; set; }
    public decimal? Price { get; set; }
}
