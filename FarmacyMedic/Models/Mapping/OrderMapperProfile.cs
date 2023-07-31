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

            CreateMap<Order, ClientDto>();

            CreateMap<ProductDetailCreationDto, ProductDetail>();
        }
    }
}
