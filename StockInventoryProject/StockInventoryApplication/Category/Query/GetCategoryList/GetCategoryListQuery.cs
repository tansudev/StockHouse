using System;
using MediatR;

namespace StockInventoryApplication.Category.Query.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<CategoryDto>>
{

}
