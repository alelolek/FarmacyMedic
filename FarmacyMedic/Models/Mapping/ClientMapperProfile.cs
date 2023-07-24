using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<ClientCreationDto, Client>();
            CreateMap<Client,ClientDto>();
        }
    }
}
