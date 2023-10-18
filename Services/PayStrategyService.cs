using ProvaPub.Enums;
using ProvaPub.Models;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class PayStrategyService : IPayStrategyService
    {
        private readonly IEnumerable<IPayService> _services;

        public PayStrategyService(IEnumerable<IPayService> services)
        {
            _services = services;
        }
        public Task<Order> PayOrder(PaymentMethodEnum paymentMethodEnum, decimal valor, int customerId)
        {
            var retorno  = _services.FirstOrDefault(x => x.paymentMethodEnum == paymentMethodEnum)?
               .PayOrder(valor, customerId) ?? throw new ArgumentNullException(nameof(paymentMethodEnum));
            return retorno;
        }
    }
}
