using FarmacyMedic.Models.DAO.Entities;

namespace FarmacyMedic.Models.DTO
{
    public class OrderCreationDto
    {
        public DateTime DateCreation { get; set; }
        public int ClientId { get; set; }
        public List<OrderProductDto> Products { get; set; }
    }

}
