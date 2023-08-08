using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.Enums;

namespace FarmacyMedic.Models.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceState State { get; set; }
    }
}
