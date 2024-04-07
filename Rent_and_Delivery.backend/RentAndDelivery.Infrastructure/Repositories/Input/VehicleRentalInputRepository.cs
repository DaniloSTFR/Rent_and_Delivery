using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Infrastructure.Context;

namespace RentAndDelivery.Infrastructure.Repositories.Input
{
    public class VehicleRentalInputRepository : IVehicleRentalInputRepository
    {
        protected readonly AppDbContext db;

        public VehicleRentalInputRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<VehicleRental> AddVehicleRental(VehicleRental vehicleRental)
        {
            if (vehicleRental is null)
                throw new ArgumentNullException(nameof(vehicleRental));

            await db.VehiclesRentals.AddAsync(vehicleRental);
            return vehicleRental;
        }

        public async Task<VehicleRental> DeleteVehicleRental(string vehicleRentalId)
        {
            var vehicleRental = await db.VehiclesRentals.FindAsync(new Guid(vehicleRentalId));

            if (vehicleRental is null)
                throw new InvalidOperationException("VehicleRental not found!");

            db.VehiclesRentals.Remove(vehicleRental);
            return vehicleRental;
        } 

        public void UpdateVehicleRental(VehicleRental vehicleRental)
        {
            if (vehicleRental is null)
                throw new ArgumentNullException(nameof(vehicleRental));

            db.VehiclesRentals.Update(vehicleRental);
        }
    }
}