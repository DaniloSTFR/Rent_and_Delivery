using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;

namespace RentAndDelivery.Application.Handlers.DeliveryPersonHandlers.Queries
{
    public class GetDeliveryPersonsQuery : IRequest<IEnumerable<DeliveryPerson>>
    {
        public class GetDeliveryPersonsQueryHandler : IRequestHandler<GetDeliveryPersonsQuery, IEnumerable<DeliveryPerson>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetDeliveryPersonsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<DeliveryPerson>> Handle(GetDeliveryPersonsQuery request, CancellationToken cancellationToken)
            {
                var deliveryPersons = await _unitOfWork.DeliveryPersonOutputRepository.GetDeliveryPersons();
                return deliveryPersons;
            }
        }
    }
}