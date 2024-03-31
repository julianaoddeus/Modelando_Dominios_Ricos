
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("1234", DocumentTypeEnum.CNPJ);
            Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        [DataRow("77.010.786/0001-52")]
        [DataRow("00.800.367/0001-90")]
        [DataRow("06.299.336/0001-83")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
        {
            var doc = new Document(cnpj, DocumentTypeEnum.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("47117801069")]
        [DataRow("829.049.880-25")]
        [DataRow("924.717.990-43")]
        public void ShouldReturnErrorWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, DocumentTypeEnum.CPF);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]       
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", DocumentTypeEnum.CPF);
            Assert.IsTrue(!doc.IsValid);
        }
    }
}