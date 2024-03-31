using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubsciption()
        {
            var name = new Name("Bruce", "Waynne");
            var document = new Document("35274547800", Domain.Enums.DocumentTypeEnum.CPF);
            var address = new Address("Rua 1", "345", "Nova","Sao Manuel", "SP", "BR","13466000");
            var email = new Email("bw@example.com");
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678",DateTime.Now, DateTime.Now.AddDays(5), 10,10,"Wainne", document,address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            student.AddSubscription(subscription);
            
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubsciptionNoPayment()
        {
            var name = new Name("Bruce", "Waynne");
            var document = new Document("35274547800", Domain.Enums.DocumentTypeEnum.CPF);
            var email = new Email("bw@example.com");
            var student = new Student(name, document, email);
            
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadActiveSubsciption()
        {
            Assert.Fail();
        }
    }
}