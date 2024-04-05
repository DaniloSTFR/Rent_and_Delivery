

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IOrderInputRepository
    {
        Task<Order> AddOrder(Order order);
        void UpdateOrder(Order order);
        Task<Order> DeleteOrder(string orderId);
    }
}