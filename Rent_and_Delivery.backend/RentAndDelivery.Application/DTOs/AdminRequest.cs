using MediatR;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.DTOS
{
    public abstract class AdminRequest 
    {
        public string? Name { get; set; }
 
    }
}