using FarmacyMedic.Models.DAO.Entities;
using FarmacyMedic.Models.Enums;

namespace FarmacyMedic.Models.DTO
{
    public class InvoiceCreacionDto
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceState State { get; set; }
    }
}
