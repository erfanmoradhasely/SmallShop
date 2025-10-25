using SmallShop.Application.Common;
using SmallShop.Application.Products.Create;
using SmallShop.Contracts.Logging;
using SmallShop.Contracts.Persistence;
using SmallShop.Domain.ProductAgg;
using SmallShop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Application.Products.Delete
{
    public class DeleteProductCommandHandler : IBaseCommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<DeleteProductCommandHandler> _appLogger;
        public DeleteProductCommandHandler(IProductRepository productRepository
            ,IAppLogger<DeleteProductCommandHandler> appLogger)
        {
            _productRepository = productRepository;
            _appLogger = appLogger;
        }
        public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.Id);
            if (product == null)
            {
                _appLogger.LogInformation("Product with Id {Id} was not found", request.Id);
                return OperationResult.NotFound();
            }

            product.CanBeDeletedOrUpdatedBy(request.UserId);

            _productRepository.Delete(product);

            await _productRepository.Save();

            return OperationResult.Success();
        }

    }
}
