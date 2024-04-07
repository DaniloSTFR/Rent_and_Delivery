using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class OrderInputRepository : IOrderInputRepository
    {
        protected readonly AppDbContext db;

        public OrderInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Order> AddOrder(Order order)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            await db.Orders.AddAsync(order);
            return order;
        }

        public async Task<Order> DeleteOrder(string orderId)
        {
            var order = await db.Orders.FindAsync(new Guid(orderId));

            if (order is null)
                throw new InvalidOperationException("Member not found");

            db.Orders.Remove(order);
            return order;
        }

        public void UpdateOrder(Order order)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            db.Orders.Update(order);
        }
    }
}