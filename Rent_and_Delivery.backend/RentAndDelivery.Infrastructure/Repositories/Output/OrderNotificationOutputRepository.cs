using Microsoft.EntityFrameworkCore;
using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class OrderNotificationOutputRepository : IOrderNotificationOutputRepository
    {
        protected readonly AppDbContext db;

        public OrderNotificationOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<OrderNotification> GetOrderNotificationById(string orderNotificationId)
        {
            var orderNotification = await db.OrderNotifications.FindAsync(new Guid(orderNotificationId));

            if (orderNotification is null)
                throw new InvalidOperationException("ArderNotification not found!");

            return orderNotification;
        }

        public async Task<IEnumerable<OrderNotification>> GetOrderNotificationByOrder(string orderId)
        {   
            if (string.IsNullOrEmpty(orderId))
                throw new InvalidOperationException("OrderId is null");

            var orderNotifications = await db.OrderNotifications
                    .Where(on => on.OrderId == new Guid(orderId)).ToListAsync(); 

            return orderNotifications ?? Enumerable.Empty<OrderNotification>();
        }
    }
}