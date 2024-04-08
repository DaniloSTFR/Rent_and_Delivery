using AutoMapper;
using RentAndDelivery.Application.DTOS;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.Mapping
{
    public class MotorcycleMapping : Profile
    {
        public MotorcycleMapping()
        {
            CreateMap<MotorcycleRequest, Motorcycle>();
            CreateMap<Motorcycle, MotorcycleRequest>();
        }
    }
}