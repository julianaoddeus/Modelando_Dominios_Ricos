using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Enums;

namespace PaymentContext.Tests
{
    [TestClass]
    public class CreateCreditCardSubscriptionCommandTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid() {
            var command = new Domain.Commands.CreateCreditCardSubscriptionCommand
            {
                FirstName = ""
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

        }

    }
}
