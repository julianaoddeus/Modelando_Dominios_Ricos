using PaymentContext.Shared.Models;

namespace PaymentContext.Domain.Models
{
    public class PayPalSubscription : PaymentSubscription
    {        
        public string TransactionCode { get; set; }   
       
    }
}