using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
           
        }

        public bool DocumentExists(string document)
        {
             if(document == "47117801069")
             return true;

             return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "hello@balta.io2")
                return true;

            return false;
        }
    }
}