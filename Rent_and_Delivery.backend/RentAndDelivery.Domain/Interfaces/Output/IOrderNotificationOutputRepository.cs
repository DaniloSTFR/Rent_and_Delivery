

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IOrderNotificationOutputRepository
    {
        Task<OrderNotification> GetOrderNotificationById(string orderNotificationId);
        Task<IEnumerable<OrderNotification>> GetOrderNotificationByOrder(string orderId);
    }
}