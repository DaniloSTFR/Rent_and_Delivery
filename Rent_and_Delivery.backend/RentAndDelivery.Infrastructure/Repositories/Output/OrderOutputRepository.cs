using Microsoft.EntityFrameworkCore;
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

            /*if (arder is null)
                throw new InvalidOperationException("Order not found!");*/

            return arder;
        }
        
        public async Task<IEnumerable<Order>> GetOrderStatus(OrderStatusType status)
        {   
            var orders = await db.Orders
                    .Where(on => on.OrderStatusStatus == status).ToListAsync(); 
                                  
            return orders ?? Enumerable.Empty<Order>();
        }
    }
}