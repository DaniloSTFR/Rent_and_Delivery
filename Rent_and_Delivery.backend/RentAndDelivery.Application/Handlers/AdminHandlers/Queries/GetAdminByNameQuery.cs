using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Queries
{
    public class GetAdminByNameQuery : IRequest<Admin>
    {
        public string Name { get; set; }
        public class GetAdminByNameQueryHandler : IRequestHandler<GetAdminByNameQuery, Admin>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAdminByNameQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Admin> Handle(GetAdminByNameQuery request, CancellationToken cancellationToken)
            {
                var admin = await _unitOfWork.AdminOutputRepository.GetAdminByName(request.Name);
                return admin;
            }
        }
    }
}