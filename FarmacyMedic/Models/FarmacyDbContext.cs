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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new {p.OrderId,p.ProductId});
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
