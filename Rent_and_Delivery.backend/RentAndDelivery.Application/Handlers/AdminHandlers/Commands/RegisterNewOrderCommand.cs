using RentAndDelivery.Domain.Entities;
using MediatR;
using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Application.DTOS;
using AutoMapper;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Commands
{
    public class RegisterNewOrderCommand : OrderRequest, IRequest<Order>
    {
        public class RegisterNewOrderCommandHandler : IRequestHandler<RegisterNewOrderCommand, Order>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public RegisterNewOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Order> Handle(RegisterNewOrderCommand request, CancellationToken cancellationToken)
            {
                var toCreateOrder = _mapper.Map<Order>(request);
                var createdOrder = await _unitOfWork.OrderInputRepository.AddOrder(toCreateOrder);
                await _unitOfWork.CommitAsync();
                return createdOrder;
            }
        }

    }
}