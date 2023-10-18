using ProvaPub.Enums;
using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PayCreditCardService : IPayService
    {
        public PaymentMethodEnum paymentMethodEnum => PaymentMethodEnum.CreditCard;

        public async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
