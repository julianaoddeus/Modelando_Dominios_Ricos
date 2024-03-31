using PaymentContext.Shared.Models;

namespace PaymentContext.Domain.Models
{
    public class BoletoSubscription : PaymentSubscription
    {
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }   
    }
}