using SmallShop.Application.Common;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg.Services;

namespace SmallShop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;


        public EditProductCommandHandler(IProductDomainService productDomainService, IProductRepository productRepository)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.Id);
            if (product == null)
                return OperationResult.NotFound();

            await product.Edit(request.Name, request.ManufacturerEmail, request.ProductionDate,
                request.ManufacturerPhoneNumber, request.IsAvailable, request.UserId, _productDomainService);

            await _productRepository.Save();

            return OperationResult.Success();
        }
    }
}