using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, DocumentTypeEnum type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(ValidateCPFOrCNPJ(), "Document.Number", "Documento inválido")
            );
        }
        public string Number { get; private set; }
        public DocumentTypeEnum Type { get; private set; }


        private bool ValidateCPFOrCNPJ()
        {

            if (Type == DocumentTypeEnum.CNPJ && Number.Length == 14)
                return true;

            if (Type == DocumentTypeEnum.CPF && Number.Length == 11)
                return true;
                
            return false;
        }

        

    }


}