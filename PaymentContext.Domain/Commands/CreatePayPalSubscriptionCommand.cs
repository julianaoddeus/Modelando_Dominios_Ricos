
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Models;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : PayPalSubscription, ICommand
    {
        
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsMinValue(3, "PaymentSubscription.FirstName", "Nome deve conter pelo menos 3 caracteres")
                .IsMinValue(3, "PaymentSubscription.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                .IsMaxValue(40, "PaymentSubscription.FirstName", "Nome deve conter até 40 caracteres")
            );   
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "PaymentSubscription.Email", "E-mail inválido")
            );

           
        }
    }
}