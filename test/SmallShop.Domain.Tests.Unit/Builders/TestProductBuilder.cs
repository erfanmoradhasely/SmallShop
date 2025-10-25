using SmallShop.Domain.ProductAgg;
using SmallShop.Domain.ProductAgg.Services;

namespace Academy.Domain.Tests.Unit.Builders
{
    public class TestProductBuilder
    {

        private string _name = "iphone 16";
        private string _manufacturerEmail = "google@gmail.com";
        private DateOnly _productionDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-1));
        private string _manufacturerPhoneNumber = "09123456789";
        private bool _isAvailable = true;
        private Guid _userId = Guid.NewGuid();

        public TestProductBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public TestProductBuilder WithManufacturerEmail(string email)
        {
            _manufacturerEmail = email;
            return this;
        }
        public TestProductBuilder WithProductionDate(DateOnly date)
        {
            _productionDate = date;
            return this;
        }
        public TestProductBuilder WithManufacturerPhoneNumber(string phoneNumber)
        {
            _manufacturerPhoneNumber = phoneNumber;
            return this;
        }
        public TestProductBuilder WithAvailablity(bool isAvailable)
        {
            _isAvailable = isAvailable;
            return this;
        }
        public TestProductBuilder WithUserId(Guid userId)
        {
            _userId = userId;
            return this;
        }

        public Product Build(IProductDomainService productDomainService)
        {
            return new Product(_name,_manufacturerEmail,_productionDate,_manufacturerPhoneNumber,
                _isAvailable,_userId, productDomainService);
        }
    }
}