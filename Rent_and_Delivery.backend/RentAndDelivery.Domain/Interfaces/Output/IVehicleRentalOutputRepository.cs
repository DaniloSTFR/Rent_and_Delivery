

using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Domain.Interfaces.Output
{
    public interface IVehicleRentalOutputRepository
    {
        Task<VehicleRental> GetVehicleRentalById(string vehicleRentalId);
        //Task<IEnumerable<VehicleRental>> GetVehicleRentalByDate();
    }
}