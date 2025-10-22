namespace StockInventoryApplication.Inventories.Query.GetInventoryList;

public class InventoryDto
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public bool IsActive { get; set; }
}
