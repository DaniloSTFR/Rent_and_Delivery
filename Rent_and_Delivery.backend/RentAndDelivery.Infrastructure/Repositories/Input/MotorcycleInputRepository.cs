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

        public async Task<Motorcycle> AddMotorcycle(Motorcycle motorcycle)
        {
            if (motorcycle is null)
                throw new ArgumentNullException(nameof(motorcycle));

            await db.Motorcycles.AddAsync(motorcycle);
            return motorcycle;
        }

        public async Task<Motorcycle> DeleteMotorcycle(string motorcycleId)
        {
            var motorcycle = await db.Motorcycles.FindAsync(new Guid(motorcycleId));

            if (motorcycle is null)
                throw new InvalidOperationException("Motorcycle not found!");

            db.Motorcycles.Remove(motorcycle);
            return motorcycle;
        }   


        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            if (motorcycle is null)
                throw new ArgumentNullException(nameof(motorcycle));

            db.Motorcycles.Update(motorcycle);
        }
    }
}