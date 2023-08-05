using FarmacyMedic.Models.DAO.Entities;

namespace FarmacyMedic.Models.DTO
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public ProductDto Product { get; set; }
    }
}
