using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class MotorcycleOutputRepository : IMotorcycleOutputRepository
    {
        protected readonly AppDbContext db;

        public MotorcycleOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public Task<IEnumerable<Motorcycle>> GetMotorcycle()
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetMotorcycleById(string motorcycleId)
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetMotorcycleByPlate(string plate)
        {
            throw new NotImplementedException();
        }
    }
}