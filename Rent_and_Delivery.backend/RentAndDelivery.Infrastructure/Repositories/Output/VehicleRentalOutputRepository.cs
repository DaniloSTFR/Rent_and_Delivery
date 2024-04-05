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

        public Task<VehicleRental> GetVehicleRentalById(string vehicleRentalId)
        {
            throw new NotImplementedException();
        }
    }
}