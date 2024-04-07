using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Motorcycle>> GetMotorcycle()
        {
            var motorcyclelist = await db.Motorcycles.ToListAsync();
            return motorcyclelist ?? Enumerable.Empty<Motorcycle>();
        }

        public async Task<Motorcycle> GetMotorcycleById(string motorcycleId)
        {
            var motorcycle = await db.Motorcycles.FindAsync(new Guid(motorcycleId));

            if (motorcycle is null)
                throw new InvalidOperationException("MotorcycleId not found!");

            return motorcycle;
        }

        public async Task<Motorcycle> GetMotorcycleByPlate(string plate)
        {   
            if (string.IsNullOrEmpty(plate))
                throw new InvalidOperationException("Plate is null");

            var motorcycle = await db.Motorcycles
                    .FirstOrDefaultAsync(ad => ad.Plate == plate);

            /* if (motorcycle is null)
                throw new InvalidOperationException("Motorcycles not found!"); */
                
            return  motorcycle;
        }
    }
}