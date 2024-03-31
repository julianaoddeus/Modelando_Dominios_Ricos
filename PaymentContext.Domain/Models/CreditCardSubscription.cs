using PaymentContext.Shared.Models;

namespace PaymentContext.Domain.Models
{
    public class CreditCardSubscription : PaymentSubscription
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }     
    }
}