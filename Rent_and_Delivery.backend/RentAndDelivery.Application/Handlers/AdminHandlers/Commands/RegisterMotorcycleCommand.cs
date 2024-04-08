using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Application.DTOS;
using AutoMapper;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Commands
{
    public class RegisterMotorcycleCommand : MotorcycleRequest, IRequest<Motorcycle>
    {
        public class RegisterMotorcycleCommandHandler : IRequestHandler<RegisterMotorcycleCommand, Motorcycle>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public RegisterMotorcycleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Motorcycle> Handle(RegisterMotorcycleCommand request, CancellationToken cancellationToken)
            {
                var toCreateMotorcycle = _mapper.Map<Motorcycle>(request);

                var existMotorcyclePlate = await _unitOfWork.MotorcycleOutputRepository.GetMotorcycleByPlate(toCreateMotorcycle.Plate);
                if (existMotorcyclePlate is not null)
                    throw new InvalidOperationException("The plate is already associated with another vehicle!");

                var createdMotorcycle = await _unitOfWork.MotorcycleInputRepository.AddMotorcycle(toCreateMotorcycle);
                await _unitOfWork.CommitAsync();
                return createdMotorcycle;
            }
        }
        
    }
}