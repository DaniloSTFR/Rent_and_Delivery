using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Domain.Interfaces.Input;
using RentAndDelivery.Domain.Interfaces.Output;
using RentAndDelivery.Infrastructure.Context;
using RentAndDelivery.Infrastructure.Repositories.Input;
using RentAndDelivery.Infrastructure.Repositories.Output;

namespace RentAndDelivery.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IAdminInputRepository? _adminInput;
        private IDeliveryPersonInputRepository? _deliveryPersonInput;
        private IMotorcycleInputRepository? _motorcycleInput;
        private IOrderNotificationInputRepository? _orderNotificationInput;
        private IOrderInputRepository? _orderInput;
        private IRentalPlanInputRepository? _rentalPlanInput;
        private IVehicleRentalInputRepository? _vehicleRentalInput;
        private IAdminOutputRepository? _adminOutput;
        private IDeliveryPersonOutputRepository? _deliveryPersonOutput;
        private IMotorcycleOutputRepository? _motorcycleOutput;
        private IOrderNotificationOutputRepository? _orderNotificationOutput;
        private IOrderOutputRepository? _orderOutput;
        private IRentalPlanOutputRepository? _rentalPlanOutput;
        private IVehicleRentalOutputRepository? _vehicleRentalOutput;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IAdminInputRepository AdminInputRepository
        {
            get
            {
                return _adminInput = _adminInput ?? 
                    new AdminInputRepository(_context);
            }
        }

        public IDeliveryPersonInputRepository DeliveryPersonInputRepository
        {
            get
            {
                return _deliveryPersonInput = _deliveryPersonInput ?? 
                    new DeliveryPersonInputRepository(_context);
            }
        }

        public IMotorcycleInputRepository MotorcycleInputRepository
        {
            get
            {
                return _motorcycleInput = _motorcycleInput ?? 
                    new MotorcycleInputRepository(_context);
            }
        }

        public IOrderNotificationInputRepository OrderNotificationInputRepository
        {
            get
            {
                return _orderNotificationInput = _orderNotificationInput ?? 
                    new OrderNotificationInputRepository(_context);
            }
        }

        public IOrderInputRepository OrderInputRepository
        {
            get
            {
                return _orderInput = _orderInput ?? 
                    new OrderInputRepository(_context);
            }
        }

        public IRentalPlanInputRepository RentalPlanInputRepository
        {
            get
            {
                return _rentalPlanInput = _rentalPlanInput ?? 
                    new RentalPlanInputRepository(_context);
            }
        }

        public IVehicleRentalInputRepository VehicleRentalInputRepository
        {
            get
            {
                return _vehicleRentalInput = _vehicleRentalInput ?? 
                    new VehicleRentalInputRepository(_context);
            }
        }

        public IAdminOutputRepository AdminOutputRepository
        {
            get
            {
                return _adminOutput = _adminOutput ?? 
                    new AdminOutputRepository(_context);
            }
        }

        public IDeliveryPersonOutputRepository DeliveryPersonOutputRepository
        {
            get
            {
                return _deliveryPersonOutput = _deliveryPersonOutput ?? 
                    new DeliveryPersonOutputRepository(_context);
            }
        }

        public IMotorcycleOutputRepository MotorcycleOutputRepository
        {
            get
            {
                return _motorcycleOutput = _motorcycleOutput ?? 
                    new MotorcycleOutputRepository(_context);
            }
        }

        public IOrderNotificationOutputRepository OrderNotificationOutputRepository
        {
            get
            {
                return _orderNotificationOutput = _orderNotificationOutput ?? 
                    new OrderNotificationOutputRepository(_context);
            }
        }

        public IOrderOutputRepository OrderOutputRepository
        {
            get
            {
                return _orderOutput = _orderOutput ?? 
                    new OrderOutputRepository(_context);
            }
        }

        public IRentalPlanOutputRepository RentalPlanOutputRepository
        {
            get
            {
                return _rentalPlanOutput = _rentalPlanOutput ?? 
                    new RentalPlanOutputRepository(_context);
            }
        }

        public IVehicleRentalOutputRepository VehicleRentalOutputRepository
        {
            get
            {
                return _vehicleRentalOutput = _vehicleRentalOutput ?? 
                    new VehicleRentalOutputRepository(_context);
            }
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}