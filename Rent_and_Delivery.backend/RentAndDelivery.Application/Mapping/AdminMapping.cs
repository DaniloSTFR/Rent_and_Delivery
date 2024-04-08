using AutoMapper;
using RentAndDelivery.Application.DTOS;
using RentAndDelivery.Domain.Entities;

namespace RentAndDelivery.Application.Mapping
{
    public class AdminMapping : Profile
    {
        public AdminMapping()
        {
            CreateMap<AdminRequest, Admin>();
            CreateMap<Admin, AdminRequest>();
        }
    }
}