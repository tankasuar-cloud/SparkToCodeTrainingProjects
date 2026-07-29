using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Controllers
{
    public class ProductController
    {
        
        private Projectcontext context;
        public ProductController(Projectcontext context)
        {
            context = context;
        }
        public void AddProduct(Product p)
        {
            context.Product.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
           Product productt= context.Product.FirstOrDefault(p => p.ProductId == id);
            if (productt == null )
            {

            }
            else
            {
                context.Product.Remove(productt);
                context.SaveChanges();
            }
        }
        public Product GetProduct(int id)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            return productt;
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = context.Product.ToList();
            return products;

        }

    }
}
