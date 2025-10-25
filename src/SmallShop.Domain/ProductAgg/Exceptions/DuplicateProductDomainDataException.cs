using SmallShop.Domain.Common.Exceptions;

namespace SmallShop.Domain.ProductAgg.Exceptions
{
    public class DuplicateProductDomainDataException : BaseDomainException
    {
        public DuplicateProductDomainDataException()
        {

        }
        public DuplicateProductDomainDataException(string message = "محصول تکراری است") : base(message)
        {

        }
    }
}