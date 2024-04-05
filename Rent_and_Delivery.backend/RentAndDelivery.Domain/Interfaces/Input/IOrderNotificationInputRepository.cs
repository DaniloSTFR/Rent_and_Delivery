

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IOrderNotificationInputRepository
    {
        Task<OrderNotification> AddOrderNotification(OrderNotification orderNotification);
        void UpdateOrderNotification(OrderNotification orderNotification);
        Task<OrderNotification> DeleteOrderNotification(string orderNotificationId);
    }
}