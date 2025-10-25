
using SmallShop.Domain.Common.Exceptions;
using SmallShop.Domain.Common.Utils;

namespace SmallShop.Domain.Common.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is < 11 or > 11)
            throw new InvalidPhoneNumberDomainDataException();
        Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator PhoneNumber(string value) => new PhoneNumber(value);
    public static implicit operator string(PhoneNumber number) => number.Value;
}