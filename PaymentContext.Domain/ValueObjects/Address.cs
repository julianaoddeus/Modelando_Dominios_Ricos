using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications( new Contract<Notification>()
                .Requires()
                .IsMinValue(3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")   
                .IsNullOrEmpty(Number, "O número é obrigatório.")     
                .IsNullOrEmpty(Neighborhood, "O bairro é obrigatório.")
                .IsNullOrEmpty(City, "O nome da cidade é obrigatório.")
                .IsNullOrEmpty(State, "O nome do estado é obrigatório.")
                .IsNullOrEmpty(ZipCode, "O CEP é obrigatório.")
                .IsMinValue(8, "CEP deve ter pelo menos 8 digítos.")
            );
        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        
        
    }
}