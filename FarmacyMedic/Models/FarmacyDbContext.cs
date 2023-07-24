using FarmacyMedic.Models.DAO.Entities;
using Microsoft.EntityFrameworkCore;
using FarmacyMedic.Models.DTO;

namespace FarmacyMedic.Models
{
	public class FarmacyDbContext : DbContext
	{
        public FarmacyDbContext(DbContextOptions options) : base(options)
		{
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FarmacyMedic.Models.DTO.OrderDto> OrderDto { get; set; }

    }
}
