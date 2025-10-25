using SmallShop.Application.Common;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg;
using SmallShop.Domain.ProductAgg.Services;

namespace SmallShop.Application.Products.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductDomainService productDomainService, IProductRepository productRepository)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.ManufacturerEmail, request.ProductionDate
                , request.ManufacturerPhoneNumber, request.IsAvailable, request.UserId, _productDomainService);

            _productRepository.Add(product);

            await _productRepository.Save();

            return OperationResult.Success();
        }
    }
}