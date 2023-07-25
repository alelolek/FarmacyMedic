namespace FarmacyMedic.Models.DTO
{
    public class PrOrCreationDto
    {
        public OrderDto Order { get; set; }
        public List<OrderProductDto> ProductsByOrder { get; set; }
    }
}
