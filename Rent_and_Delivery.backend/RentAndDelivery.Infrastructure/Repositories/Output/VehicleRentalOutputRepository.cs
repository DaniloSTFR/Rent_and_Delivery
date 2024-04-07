using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Output
{
    public class VehicleRentalOutputRepository : IVehicleRentalOutputRepository
    {
        protected readonly AppDbContext db;

        public VehicleRentalOutputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<VehicleRental> GetVehicleRentalById(string vehicleRentalId)
        {
            var Vehicle = await db.VehiclesRentals.FindAsync(new Guid(vehicleRentalId));

            if (Vehicle is null)
                throw new InvalidOperationException("Vehicles not found!");

            return Vehicle;
        }
    }
}