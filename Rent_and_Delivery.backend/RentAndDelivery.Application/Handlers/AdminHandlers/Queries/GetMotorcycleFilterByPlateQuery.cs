using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces;
using MediatR;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Queries
{
    public class GetMotorcycleFilterByPlateQuery : IRequest<IEnumerable<Motorcycle>>
    {
        public string? Plate  { get; set; }

        public class GetMotorcycleFilterByPlateQueryHandler : IRequestHandler<GetMotorcycleFilterByPlateQuery, IEnumerable<Motorcycle>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetMotorcycleFilterByPlateQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Motorcycle>> Handle(GetMotorcycleFilterByPlateQuery request, CancellationToken cancellationToken)
            {
                var motorcycles = await _unitOfWork.MotorcycleOutputRepository.GetMotorcycleFilterByPlate(request.Plate);
                return motorcycles;
            }
        }
    }
}