using MediatR;

namespace StockInventoryApplication.Categories.Query.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<CategoryDto>>
{

}
