using Microsoft.EntityFrameworkCore;
using TicketAPI.Models;

namespace TicketAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Ticket entity
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasPrecision(18, 2); // For decimal precision

            // Add some seed data
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, EventName = "Rock Concert", Type = "VIP", Price = 150.00m, EventDate = DateTime.Now.AddDays(10) },
                new Ticket { Id = 2, EventName = "Theater Play", Type = "Regular", Price = 45.00m, EventDate = DateTime.Now.AddDays(15) },
                new Ticket { Id = 3, EventName = "Sports Game", Type = "Front Row", Price = 85.00m, EventDate = DateTime.Now.AddDays(20) }
            );
        }
    }
}