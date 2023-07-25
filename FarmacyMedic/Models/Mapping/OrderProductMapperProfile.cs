using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
    public class OrderProductMapperProfile : Profile
    {
        public OrderProductMapperProfile()
        {
            CreateMap<OrderProduct, OrderProductDto>();
        }
    }
}
