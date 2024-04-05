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

        public Task<Order> AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> DeleteOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}