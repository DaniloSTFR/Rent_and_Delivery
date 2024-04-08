using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Queries
{
    public class GetAdminByIdQuery : IRequest<Admin>
    {
        public string Id { get; set; }
        public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, Admin>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAdminByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Admin> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
            {
                var admin = await _unitOfWork.AdminOutputRepository.GetAdminById(request.Id);
                return admin;
            }
        }
    }
}