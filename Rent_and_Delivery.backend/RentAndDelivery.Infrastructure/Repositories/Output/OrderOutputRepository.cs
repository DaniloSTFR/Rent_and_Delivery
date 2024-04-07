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

        public async Task<Order> GetOrderById(string orderId)
        {
            var arder = await db.Orders.FindAsync(new Guid(orderId));

            if (arder is null)
                throw new InvalidOperationException("Admin not found!");

            return arder;
        }
        
        public Task<IEnumerable<Order>> GetOrderStatus(OrderStatusType Status)
        {
            throw new NotImplementedException();
        }
    }
}