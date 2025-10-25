using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg.Services;

namespace SmallShop.Application.Products;

public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;

    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ProductExists(string manufacturerEmail, DateOnly productionDate)
    {
        return await _repository.ExistsAsync(x => x.ManufacturerEmail == manufacturerEmail
                    && x.ProductionDate == productionDate);
    }

}