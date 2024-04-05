using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IMotorcycleOutputRepository
    {
        Task<Motorcycle> GetMotorcycleById(string motorcycleId);
        Task<IEnumerable<Motorcycle>> GetMotorcycle();
        Task<Motorcycle> GetMotorcycleByPlate(string plate);
    }
}