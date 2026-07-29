using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        
        private Projectcontext context;
        public ProductController(Projectcontext context)
        {
            context = context;
        }
        [HttpPost("AddProduct")]
        public void AddProduct(Product p)
        {
            context.Product.Add(p);
            context.SaveChanges();
        }


        [HttpDelete("DeleteProduct")]
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


        [HttpGet("GetProduct")]
        public Product GetProduct(int id)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            return productt;
        }


        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            List<Product> products = context.Product.ToList();
            return products;

        }


        [HttpGet("GetByName")]
        public List<Product> GetByName(string name)
        {
            List<Product> products = context.Product.Where(p=>p.ProductName.Contains( name)).ToList();
            return products;
        }


        [HttpPatch("UpdateProductPrice")]
        public void UpdateProductPrice(int id,decimal newPrice)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price = newPrice;
            context.SaveChanges();
        }


        [HttpPatch("UpdateProductname")]
        public void UpdateProductname(int id, string name)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.ProductName = name;
            context.SaveChanges();
        }



        [HttpPut("updateProduct")]
        public void updateProduct(int id, Product newproduct)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price=newproduct.Price;
            productt.ProductName = newproduct.ProductName;
            productt.ProductDescription = newproduct.ProductDescription;
            context.SaveChanges();


        }



    }
}
