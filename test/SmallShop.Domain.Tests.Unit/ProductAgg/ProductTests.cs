using FluentAssertions;
using NSubstitute;
using SmallShop.Domain.Common.ValueObjects;
using SmallShop.Domain.ProductAgg;
using SmallShop.Domain.ProductAgg.Services;
using System.Xml.Linq;
using SmallShop.Domain.ProductAgg.Exceptions;
using SmallShop.Domain.Tests.Unit.Builders;


namespace SmallShop.Domain.Tests.Unit.ProductAgg
{
    public class ProductTests
    {
        private readonly TestProductBuilder _productBuilder;
        private readonly IProductDomainService _productDomainService;
        public ProductTests()
        {
            _productBuilder = new TestProductBuilder();
            _productDomainService = Substitute.For<IProductDomainService>();
            _productDomainService.ProductExists(Arg.Any<string>(), Arg.Any<DateOnly>())
                .Returns(Task.FromResult(false));
        }


        [Fact]
        public void Constructor_ShouldAssignValuesProperly()
        {
            const string name = "Samsung Galaxy S24";
            const string manufacturerEmail = "erfanmoradhase@gmail.com";
            var productionDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-1));
            const string manufacturerPhoneNumber = "09876543210";
            const bool isAvailable = true;
            var userId = Guid.NewGuid();


            var product = _productBuilder.WithName(name).WithManufacturerEmail(manufacturerEmail)
                .WithProductionDate(productionDate).WithManufacturerPhoneNumber(manufacturerPhoneNumber)
                .WithAvailablity(isAvailable).WithUserId(userId).Build(_productDomainService);

            product.Name.Should().Be(name);
            product.ManufacturerEmail.Should().Be((Email)manufacturerEmail);
            product.ProductionDate.Should().Be((productionDate));
            product.ManufacturerPhoneNumber.Should().Be((PhoneNumber)manufacturerPhoneNumber);
            product.IsAvailable.Should().Be(isAvailable);
            product.UserId.Should().Be(userId);
        }

        [Fact]
        public void Constructor_ShouldThrowDuplicateProductDomainDataException_WhenEmailAndDateIsDuplicate()
        {
            _productDomainService.ProductExists(Arg.Any<string>(), Arg.Any<DateOnly>())
                .Returns(Task.FromResult(true));

            var action = () => _productBuilder.Build(_productDomainService);

            action.Should().ThrowExactly<DuplicateProductDomainDataException>();
        }

        [Fact]
        public void Edit_ShouldThrowDuplicateProductDomainDataException_WhenEmailAndDateIsDuplicate()
        {
            var product = _productBuilder.Build(_productDomainService);
            _productDomainService.ProductExists(Arg.Any<string>(), Arg.Any<DateOnly>())
                .Returns(Task.FromResult(true));


            var action = async () =>
            {
                await product.Edit(product.Name, product.ManufacturerEmail, product.ProductionDate
                , product.ManufacturerPhoneNumber, product.IsAvailable, product.UserId, _productDomainService);
            };

            action.Should().ThrowExactlyAsync<DuplicateProductDomainDataException>();
        }
        [Fact]
        public void Edit_ShouldThrowInvalidUserDomainDataException_WhenUserIdIsNotTheSame()
        {
            var product = _productBuilder.Build(_productDomainService);
            var anotherUserId = Guid.NewGuid();

            var action = async () =>
            {
                await product.Edit(product.Name, product.ManufacturerEmail, product.ProductionDate
                 , product.ManufacturerPhoneNumber, product.IsAvailable, anotherUserId, _productDomainService);
            };

            action.Should().ThrowExactlyAsync<InvalidUserDomainDataException>();
        }
        [Fact]
        public async void Edit_ShouldAssignValuesProperly_WhenGivenValidData()
        {
            var productionDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3));
            var product = _productBuilder.WithProductionDate(productionDate).Build(_productDomainService);


            await product.Edit(product.Name, product.ManufacturerEmail, productionDate
             , product.ManufacturerPhoneNumber, product.IsAvailable, product.UserId, _productDomainService);


            product.ProductionDate.Should().Be(productionDate);
        }
        [Fact]
        public async void CanBeDeletedOrUpdatedBy_ShouldNotThrowWhenUserIdIsTheSame()
        {
            var product = _productBuilder.Build(_productDomainService);

            var action = () =>
            {
                product.CanBeDeletedOrUpdatedBy(product.UserId);
            };

            action.Should().NotThrow();
        }

        [Fact]
        public async void CanBeDeletedOrUpdatedBy_ShouldThrowInvalidUserDomainDataException_WhenUserIdIsNotTheSame()
        {
            var product = _productBuilder.Build(_productDomainService);
            var anotherUserId = Guid.NewGuid();

            var action = () =>
            {
                product.CanBeDeletedOrUpdatedBy(anotherUserId);
            };

            action.Should().ThrowExactly<InvalidUserDomainDataException>();
        }

    }
}