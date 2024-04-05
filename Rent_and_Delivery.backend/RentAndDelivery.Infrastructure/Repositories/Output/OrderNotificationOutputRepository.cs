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

        public Task<OrderNotification> GetOrderNotificationById(string orderNotificationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderNotification>> GetOrderNotificationByOrder(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}