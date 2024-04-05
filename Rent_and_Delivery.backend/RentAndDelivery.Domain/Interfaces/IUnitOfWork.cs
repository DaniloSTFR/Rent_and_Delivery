using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Domain.Interfaces.Output;

namespace RentAndDelivery.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAdminInputRepository AdminInputRepository { get; }
        IDeliveryPersonInputRepository DeliveryPersonInputRepository { get; }
        IMotorcycleInputRepository MotorcycleInputRepository { get; }
        IOrderNotificationInputRepository OrderNotificationInputRepository { get; }
        IOrderInputRepository OrderInputRepository { get; }
        IRentalPlanInputRepository RentalPlanInputRepository { get; }
        IVehicleRentalInputRepository VehicleRentalInputRepository { get; }

        IAdminOutputRepository AdminOutputRepository { get; }
        IDeliveryPersonOutputRepository DeliveryPersonOutputRepository { get; }
        IMotorcycleOutputRepository MotorcycleOutputRepository { get; }
        IOrderNotificationOutputRepository OrderNotificationOutputRepository { get; }
        IOrderOutputRepository OrderOutputRepository { get; }
        IRentalPlanOutputRepository RentalPlanOutputRepository { get; }
        IVehicleRentalOutputRepository VehicleRentalOutputRepository { get; }
        
        Task CommitAsync();
    }
}