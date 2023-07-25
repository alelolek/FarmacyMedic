using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
    public class InvoiceMapperProfile:Profile
    {
        public InvoiceMapperProfile()
        {
            CreateMap<InvoiceCreacionDto, Invoice>();
            CreateMap<Invoice,InvoiceDto>();
        }
    }
}
