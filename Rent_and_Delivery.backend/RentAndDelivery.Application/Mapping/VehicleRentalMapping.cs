using AutoMapper;
using RentAndDelivery.Application.DTOS;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.Mapping
{
    public class VehicleRentalMapping : Profile
    {
        public VehicleRentalMapping()
        {
            CreateMap<VehicleRentalRequest, VehicleRental>();
            CreateMap<VehicleRental, VehicleRentalRequest>();
        }
    }
}