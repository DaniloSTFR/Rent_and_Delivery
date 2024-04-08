using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces;
using MediatR;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Commands
{
    public class UpdateMotorcyclePlateCommand : IRequest<Motorcycle>
    {
        public string Id { get; set; }
        public string? Plate  { get; set; }

        public class UpdateMotorcyclePlateCommandHandler : IRequestHandler<UpdateMotorcyclePlateCommand, Motorcycle>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateMotorcyclePlateCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Motorcycle> Handle(UpdateMotorcyclePlateCommand request, CancellationToken cancellationToken)
            {
                var existingMotorcycle = await _unitOfWork.MotorcycleOutputRepository.GetMotorcycleById(request.Id);

                if (existingMotorcycle is null)
                    throw new InvalidOperationException("Motorcycle not found");

                existingMotorcycle.Update(existingMotorcycle.Year, existingMotorcycle.Model, request.Plate, existingMotorcycle.Status);

                _unitOfWork.MotorcycleOutputRepository.UpdateMotorcycle(existingMotorcycle);
                await _unitOfWork.CommitAsync();

            return existingMotorcycle;
            }
        }


    }
}