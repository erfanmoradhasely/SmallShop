using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        Task<bool> ProductExists(string manufacturerEmail, DateOnly productionDate);
    }
}
