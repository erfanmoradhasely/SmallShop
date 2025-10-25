using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg;
using SmallShop.Infrastructure.Persistence.Common;
using SmallShop.Infrastructure.Persistence.DatabaseContext;

namespace SmallShop.Infrastructure.Persistence.ProductAgg;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(SmallShopContext context) : base(context)
    {
    }
}