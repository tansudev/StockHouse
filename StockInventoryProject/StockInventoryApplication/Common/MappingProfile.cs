using AutoMapper;
using StockInventoryApplication.Categories.Query.GetCategoryList;
using StockInventoryApplication.Inventories.Query.GetInventoryList;
using StockInventoryDomain.Aggregates;
namespace StockInventoryApplication.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<Inventory, InventoryDto>();
        CreateMap<InventoryDto, Inventory>();
    }
}
