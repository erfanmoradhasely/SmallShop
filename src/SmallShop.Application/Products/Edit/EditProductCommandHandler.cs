using SmallShop.Application.Common;
using SmallShop.Application.Products.Delete;
using SmallShop.Contracts.Logging;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg.Services;

namespace SmallShop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<DeleteProductCommandHandler> _appLogger;

        public EditProductCommandHandler(IProductDomainService productDomainService
            , IProductRepository productRepository
            , IAppLogger<DeleteProductCommandHandler> appLogger)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
            _appLogger = appLogger;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.Id);
            if (product == null)
            {
                _appLogger.LogInformation("Product with Id {Id} was not found", request.Id);
                return OperationResult.NotFound();
            }


            await product.Edit(request.Name, request.ManufacturerEmail, request.ProductionDate,
                request.ManufacturerPhoneNumber, request.IsAvailable, request.UserId.Value, _productDomainService);

            await _productRepository.Save();

            return OperationResult.Success();
        }
    }
}