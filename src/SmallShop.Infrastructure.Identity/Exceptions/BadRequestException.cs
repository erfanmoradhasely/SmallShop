using FluentValidation.Results;

namespace SmallShop.Infrastructure.Identity.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {

    }
}
