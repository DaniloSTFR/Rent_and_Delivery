

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IVehicleRentalOutputRepository
    {
        Task<VehicleRental> GetVehicleRentalById(string vehicleRentalId);
        Task<VehicleRental> GetVehicleRentalByIdMotorcycle(string motorcycleId);
        //Task<IEnumerable<VehicleRental>> GetVehicleRentalByDate();
    }
}