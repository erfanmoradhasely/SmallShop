namespace SmallShop.Domain.Common.Exceptions
{
    public class InvalidEmailDomainDataException : BaseDomainException
    {
        public InvalidEmailDomainDataException()
        {

        }
        public InvalidEmailDomainDataException(string message = "ایمیل نامعتبر است") : base(message)
        {

        }
    }
}
