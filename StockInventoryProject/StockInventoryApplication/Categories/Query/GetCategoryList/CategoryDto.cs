using System;

namespace StockInventoryApplication.Categories.Query.GetCategoryList;

public class CategoryDto
{
    public Guid ParentId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Code { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
