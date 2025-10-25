using SmallShop.Application.Common;
using SmallShop.Application.Products.Create;
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

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.Id);
            if (product == null)
                return OperationResult.NotFound();

            product.CanBeDeletedOrUpdatedBy(request.UserId);

            _productRepository.Delete(product);

            await _productRepository.Save();

            return OperationResult.Success();
        }

    }
}
