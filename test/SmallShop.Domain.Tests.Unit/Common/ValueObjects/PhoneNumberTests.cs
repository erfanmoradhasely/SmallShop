using FluentAssertions;
using SmallShop.Domain.Common.Exceptions;
using SmallShop.Domain.Common.ValueObjects;

namespace SmallShop.Domain.Tests.Unit.Common.ValueObjects
{
    public class PhoneNumberTests
    {

        [Fact]
        public void Constructor_ShouldNotThrow_WhenGivenRightPhoneNumber()
        {
            const string phoneNumber = "09123456789";

            var action = () => new PhoneNumber(phoneNumber);

            action.Should().NotThrow();
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidPhoneNumberDomainDataException_WhenGivenWrongPhoneNumber()
        {
            const string phoneNumber = "1387218";

            var action = () => new PhoneNumber(phoneNumber);

            action.Should().ThrowExactly<InvalidPhoneNumberDomainDataException> ();
        }
    }
}
