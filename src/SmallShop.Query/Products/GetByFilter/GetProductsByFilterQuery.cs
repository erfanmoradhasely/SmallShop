using SmallShop.Query.Common;
using SmallShop.Query.Products.DTOs;

namespace SmallShop.Query.Products.GetByFilter;

public class GetProductsByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
{
    public GetProductsByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
    }
}