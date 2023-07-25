using AutoMapper;
using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.Mapping
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderCreationDto, Order>().
                ForMember(order=>order.OrderProduct,opciones=>opciones.MapFrom(MapOrderProduct));

            CreateMap<Order,OrderDto>().
                ForMember(orderDto=>orderDto.Products,op=>op.MapFrom(MapOrderDtoProducts));

            CreateMap<Order, ClientDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Client.Name));
        }

        private List<OrderProduct> MapOrderProduct(OrderCreationDto orderCreationDto, Order order)
        {
            var resultado = new List<OrderProduct>();
            if (orderCreationDto.Products == null)
            {
                return resultado;
            }
            foreach(var productId in orderCreationDto.Products)
            {
                resultado.Add(new OrderProduct { ProductId = productId.ProductId }); 
            }
            return resultado;
        }

        private List<ProductDto> MapOrderDtoProducts(Order order,OrderDto orderDto)
        {
            var resultado = new List<ProductDto>();

            if (order.OrderProduct == null) { return resultado; }
            foreach (var productOrder in order.OrderProduct)
            {
                resultado.Add(new ProductDto()
                {
                    Id = productOrder.ProductId,
                    Name = productOrder.Product.Name,
                    Description = productOrder.Product.Description,
                    Stock = productOrder.Product.Stock,
                    Price = productOrder.Product.Price
                });   
            }
            return resultado;
        }
    }
}
