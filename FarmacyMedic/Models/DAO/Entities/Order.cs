using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models.DAO.Entities
{
	public class Order
	{
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
