

using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IOrderOutputRepository
    {
        Task<Order> GetOrderById(string orderId);
        Task<IEnumerable<Order>> GetOrderStatus(OrderStatusType Status);
    }
}