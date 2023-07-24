using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderCreationDto, Order>();
            CreateMap<Order,OrderDto>();

            CreateMap<Order, ClientDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Client.Name));
        }
    }
}
