using NSubstitute;
using SmallShop.Application.Products.Delete;
using SmallShop.Contracts.Logging;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg;
using SmallShop.Domain.ProductAgg.Services;
using SmallShop.Domain.Tests.Unit.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Application.Tests.Unit.Products
{
    public class DeleteProductCommandHandlerTests
    {
        private readonly DeleteProductCommandHandler _handler;
        private readonly IProductRepository _repository;
        private readonly Product _product;
        public DeleteProductCommandHandlerTests()
        {
            var productDomainServcie = Substitute.For<IProductDomainService>();
            _repository = Substitute.For<IProductRepository>();
            var logger = Substitute.For<IAppLogger<DeleteProductCommandHandler>>();

            _product = new TestProductBuilder().Build(null);

            _repository.GetTracking(Arg.Any<Guid>())
                .Returns(Task.FromResult(_product));

            _handler = new DeleteProductCommandHandler(_repository, logger);

        }


        [Fact]
        public async void ShouldDeleteProductInDataBase()
        {
            var command = new DeleteProductCommand()
            {
                Id = _product.Id,
                UserId = _product.UserId,
            };
            await _handler.Handle(command, CancellationToken.None);

            _repository.Received().Delete(Arg.Any<Product>());
            await _repository.Received().Save();
        }
    }
}
