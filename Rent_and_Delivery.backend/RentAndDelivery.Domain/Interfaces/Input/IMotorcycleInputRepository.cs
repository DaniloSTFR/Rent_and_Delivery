

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IMotorcycleInputRepository
    {
        Task<Motorcycle> AddMotorcycle(Motorcycle motorcycle);
        void UpdateMotorcycle(Motorcycle motorcycle);
        Task<Motorcycle> DeleteMotorcycle(string motorcycleId);
    }
}