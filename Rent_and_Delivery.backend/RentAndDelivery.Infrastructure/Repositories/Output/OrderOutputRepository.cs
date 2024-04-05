using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Enum;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class OrderOutputRepository : IOrderOutputRepository
    {
        protected readonly AppDbContext db;

        public OrderOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public Task<Order> GetOrderById(string orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrderStatus(OrderStatusType Status)
        {
            throw new NotImplementedException();
        }
    }
}