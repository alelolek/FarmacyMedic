using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
	public class ProductMapperProfile : Profile
	{
		public ProductMapperProfile() 
		{
			CreateMap<ProductCreationDto,Product>(); //crar editar
			CreateMap<Product, ProductDto>(); //todo l demas
		}
	}
}
