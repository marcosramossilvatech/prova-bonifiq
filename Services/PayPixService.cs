using ProvaPub.Enums;
using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PayPixService : IPayService
    {
        public PaymentMethodEnum paymentMethodEnum => PaymentMethodEnum.Pix;

        public async Task<Order> PayOrder(decimal paymentValue, int customerId)
        {
            return await Task.FromResult(new Order()
            {
                Value = paymentValue,
                CustomerId = customerId
            });
        }
    }
}
