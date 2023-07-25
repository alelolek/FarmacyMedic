using FarmacyMedic.Models.DAO.Entities;

namespace FarmacyMedic.Models.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
