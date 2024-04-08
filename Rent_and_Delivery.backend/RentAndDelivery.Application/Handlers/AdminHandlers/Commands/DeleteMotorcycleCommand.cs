using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces;
using MediatR;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Commands
{
    public class DeleteMotorcycleCommand : IRequest<Motorcycle>
    {
        public string Id { get; set; }

        public class DeleteMotorcycleCommandHandler : IRequestHandler<DeleteMotorcycleCommand, Motorcycle>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteMotorcycleCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Motorcycle> Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
            {
                var vehicleRental = await _unitOfWork.VehicleRentalOutputRepository.GetVehicleRentalByIdMotorcycle(request.Id);

                if (vehicleRental is not null)
                    throw new InvalidOperationException("The motorcycle cannot be deleted as it has already been rented!");
                
                var deletedMotorcycle = await _unitOfWork.MotorcycleInputRepository.DeleteMotorcycle(request.Id);
                await _unitOfWork.CommitAsync();
                return deletedMotorcycle;
            }
        }


    }
}