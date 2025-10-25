using SmallShop.Query.Common.Filter;

namespace SmallShop.Query.Products.DTOs;

public class ProductFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
}