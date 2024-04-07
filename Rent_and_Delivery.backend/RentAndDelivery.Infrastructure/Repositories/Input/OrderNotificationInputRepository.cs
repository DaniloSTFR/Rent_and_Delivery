using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class OrderNotificationInputRepository : IOrderNotificationInputRepository
    {
        protected readonly AppDbContext db;

        public OrderNotificationInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<OrderNotification> AddOrderNotification(OrderNotification orderNotification)
        {
            if (orderNotification is null)
                throw new ArgumentNullException(nameof(orderNotification));

            await db.OrderNotifications.AddAsync(orderNotification);
            return orderNotification;
        }

        public async Task<OrderNotification> DeleteOrderNotification(string orderNotificationId)
        {
            var orderNotification = await db.OrderNotifications.FindAsync(new Guid(orderNotificationId));

            if (orderNotification is null)
                throw new InvalidOperationException("OrderNotification not found!");

            db.OrderNotifications.Remove(orderNotification);
            return orderNotification;
        } 

        public void UpdateOrderNotification(OrderNotification orderNotification)
        {
            if (orderNotification is null)
                throw new ArgumentNullException(nameof(orderNotification));

            db.OrderNotifications.Update(orderNotification);
        }
    }
}