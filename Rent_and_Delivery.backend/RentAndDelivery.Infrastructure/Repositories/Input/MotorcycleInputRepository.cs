using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;
namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class MotorcycleInputRepository : IMotorcycleInputRepository
    {
        protected readonly AppDbContext db;

        public MotorcycleInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public Task<Motorcycle> AddMotorcycle(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> DeleteMotorcycle(string motorcycleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}