using AutoMapper;
using RentAndDelivery.Application.DTOS;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderRequest>();
        }
    }
}