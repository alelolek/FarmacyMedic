namespace FarmacyMedic.Models.DTO
{
	public class ProductCreationDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
	}
}
