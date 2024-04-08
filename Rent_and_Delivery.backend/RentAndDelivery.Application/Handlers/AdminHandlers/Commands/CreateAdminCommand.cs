using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Application.DTOS;
using AutoMapper;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Commands
{
    public class CreateAdminCommand : AdminRequest, IRequest<Admin>
    {

        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Admin>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Admin> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
            {
                var toCreateAdmin = _mapper.Map<Admin>(request);
                var createdAdmin = await _unitOfWork.AdminInputRepository.AddAdmin(toCreateAdmin);
                await _unitOfWork.CommitAsync();

                return createdAdmin;
            }
        }

    }
}