using FarmacyMedic.Models.Enums;

namespace FarmacyMedic.Models.DAO.Entities
{
	public class Invoice
	{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceState State { get; set; }
    }
}
