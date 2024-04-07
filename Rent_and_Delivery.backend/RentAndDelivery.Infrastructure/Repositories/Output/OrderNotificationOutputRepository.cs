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

        public Task<IEnumerable<OrderNotification>> GetOrderNotificationByOrder(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}