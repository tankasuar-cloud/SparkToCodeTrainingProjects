using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject
{
    public class Projectcontext: DbContext
    {
        public DbSet<Product> Product {  get; set; }
        public DbSet<Category> Category { get; set; }

        public Projectcontext(DbContextOptions<Projectcontext> options) : base(options)
        {
        }

    }
}
