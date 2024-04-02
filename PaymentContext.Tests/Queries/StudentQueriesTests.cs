using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Enums;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;
        public StudentQueriesTests()
        {           
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), DocumentTypeEnum.CPF),
                    new Email(i.ToString() + "@email.com")
                ));
            }            
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists() { 
            var exp = StudentQueries.GetStudent("12345678911");
            var stdn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, stdn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists() { 
            var exp = StudentQueries.GetStudent("11111111111");
            var stdn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, stdn);
        }

    }
}
