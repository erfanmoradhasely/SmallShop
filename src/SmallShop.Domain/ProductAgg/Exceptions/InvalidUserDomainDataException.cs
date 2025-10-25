using SmallShop.Domain.Common.Exceptions;

namespace SmallShop.Domain.ProductAgg.Exceptions
{
    public class InvalidUserDomainDataException : BaseDomainException
    {
        public InvalidUserDomainDataException()
        {

        }
        public InvalidUserDomainDataException(string message = "شما مجوز این کار را ندارید") : base(message)
        {

        }
    }
}