using FluentAssertions;
using SmallShop.Domain.Common.Exceptions;
using SmallShop.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop.Domain.Tests.Unit.Common.ValueObjects
{
    public class EmailTests
    {
        public EmailTests()
        {
            
        }
        [Fact]
        public void Constructor_ShouldNotThrow_WhenGivenRightEmail()
        {
            const string email = "erfanmo@gmail.com";

            var action = () => new Email(email);

            action.Should().NotThrow();
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidEmailDomainDataException_WhenGivenWrongEmail()
        {
            const string email = "erfanmgmail.com";
            
            var action = () => new Email(email);

            action.Should().ThrowExactly<InvalidEmailDomainDataException>();
        }
    }
}
