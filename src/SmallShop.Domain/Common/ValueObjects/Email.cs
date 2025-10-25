
using SmallShop.Domain.Common.Exceptions;
using SmallShop.Domain.Common.Utils;

namespace SmallShop.Domain.Common.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.IsValidEmail())
                throw new InvalidEmailDomainDataException();
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator Email(string value) => new Email(value);
        public static implicit operator string(Email number) => number.Value;
    }
}
