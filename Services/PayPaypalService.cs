using ProvaPub.Enums;
using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PayPaypalService : IPayService
    {
        public PaymentMethodEnum paymentMethodEnum => PaymentMethodEnum.Paypal;

        public async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
