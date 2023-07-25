using FarmacyMedic.Models.DAO.Entities;

namespace FarmacyMedic.Models.DTO
{
    public class OrderProductDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
