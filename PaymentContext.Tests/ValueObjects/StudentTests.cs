using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{    
    [TestClass]
    public class StudentTests
    {
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Name _name;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Waynne");
            _document = new Document("35274547800", Domain.Enums.DocumentTypeEnum.CPF);
            _address = new Address("Rua 1", "345", "Nova","Sao Manuel", "SP", "BR","13466000");
            _email = new Email("bw@example.com");
            _student = new Student(_name, _document,  _email);
            _subscription = new Subscription(null);           
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubsciption()
        {         
             var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10,10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);   
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            
            Assert.IsFalse(_student.IsValid);
        }
        
        [TestMethod]
        public void ShouldReturnErrorWhenHadSubsciptionHasNoPayment()
        {            
            _student.AddSubscription(_subscription);            
            Assert.IsFalse(_student.IsValid);
        }

        public void ShouldReturnSuccessWhenAddSubsciption()
        {         
             var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10,10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);   
            _student.AddSubscription(_subscription);           
            
            Assert.IsTrue(_student.IsValid);
        }
       
    }
}