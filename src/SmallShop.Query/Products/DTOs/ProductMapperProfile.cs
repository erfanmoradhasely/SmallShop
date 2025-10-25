using AutoMapper;
using SmallShop.Domain.ProductAgg;


namespace SmallShop.Query.Products.DTOs;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ManufacturerPhoneNumber, 
                    opt => opt.MapFrom(src => src.ManufacturerPhoneNumber.Value))
            .ForMember(dest => dest.ManufacturerEmail,
                    opt => opt.MapFrom(src => src.ManufacturerEmail.Value));

    }
}
