using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Queries
{
    public class GetAdminsQuery : IRequest<IEnumerable<Admin>>
    {
        public class GetAdminsQueryHandler : IRequestHandler<GetAdminsQuery, IEnumerable<Admin>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAdminsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Admin>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
            {
                var admins = await _unitOfWork.AdminOutputRepository.GetAdmins();
                return admins;
            }
        }
    }
}