namespace SmallShop.Domain.Common.Exceptions;

public class InvalidPhoneNumberDomainDataException : BaseDomainException
{
    public InvalidPhoneNumberDomainDataException()
    {

    }
    public InvalidPhoneNumberDomainDataException(string message = "شماره تلفن نامعتبر است") : base(message)
    {

    }
}
