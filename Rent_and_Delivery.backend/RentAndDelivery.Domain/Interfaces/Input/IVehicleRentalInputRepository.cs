

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Input
{
    public interface IVehicleRentalInputRepository
    {
        Task<VehicleRental> AddVehicleRental(VehicleRental vehicleRental);
        void UpdateVehicleRental(VehicleRental vehicleRental);
        Task<VehicleRental> DeleteVehicleRental(string vehicleRentalId);
    }
}