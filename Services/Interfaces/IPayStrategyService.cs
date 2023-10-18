using ProvaPub.Enums;
using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IPayStrategyService
    {
        Task<Order> PayOrder(PaymentMethodEnum formaPagamento, decimal valor, int customerId);
    }
}
