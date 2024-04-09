using RentAndDelivery.Domain.Entities;
using RentAndDelivery.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RentAndDelivery.Application.Handlers.AdminHandlers.Queries
{
    public class ConsultOrdersNotificationsByOrderIdQuery : IRequest<IEnumerable<OrderNotification>>
    {
        public string OrderId { get; set; }

        public class ConsultOrdersNotificationsByOrderIdQueryHandler :
                IRequestHandler<ConsultOrdersNotificationsByOrderIdQuery, IEnumerable<OrderNotification>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public ConsultOrdersNotificationsByOrderIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<OrderNotification>> Handle(ConsultOrdersNotificationsByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var orderNotifications = await _unitOfWork.OrderNotificationOutputRepository
                                                .GetOrdersNotificationsByOrderId(request.OrderId);
                return orderNotifications;
            }
        }
    }
}