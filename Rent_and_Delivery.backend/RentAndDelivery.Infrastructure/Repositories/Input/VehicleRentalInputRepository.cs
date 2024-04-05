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

        public Task<VehicleRental> AddVehicleRental(VehicleRental vehicleRental)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleRental> DeleteVehicleRental(string vehicleRentalId)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicleRental(VehicleRental vehicleRental)
        {
            throw new NotImplementedException();
        }
    }
}