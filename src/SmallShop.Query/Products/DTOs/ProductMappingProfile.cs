using AutoMapper;
using SmallShop.Domain.ProductAgg;


namespace SmallShop.Query.Products.DTOs;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product,ProductDto>();
    }
}
