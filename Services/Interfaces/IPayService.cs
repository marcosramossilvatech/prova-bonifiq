using ProvaPub.Enums;
using ProvaPub.Models;

namespace ProvaPub.Services.Interfaces
{
    public interface IPayService
    {
        PaymentMethodEnum paymentMethodEnum { get; }
        Task<Order> PayOrder(decimal paymentValue, int customerId);
    }
}
