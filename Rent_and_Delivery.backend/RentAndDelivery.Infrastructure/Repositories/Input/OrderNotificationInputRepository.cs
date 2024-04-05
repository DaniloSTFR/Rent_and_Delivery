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

        public Task<OrderNotification> AddOrderNotification(OrderNotification orderNotification)
        {
            throw new NotImplementedException();
        }

        public Task<OrderNotification> DeleteOrderNotification(string orderNotificationId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderNotification(OrderNotification orderNotification)
        {
            throw new NotImplementedException();
        }
    }
}