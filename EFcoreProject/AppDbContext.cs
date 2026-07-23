using EFcoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Tanka\\SQLEXPRESS;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}