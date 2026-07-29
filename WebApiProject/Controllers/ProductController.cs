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
        public IActionResult AddProduct(Product p)
        {
            context.Product.Add(p);
            context.SaveChanges();
            return Ok(p.ProductId) ;
        }


        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
           Product productt= context.Product.FirstOrDefault(p => p.ProductId == id);
            if (productt == null )
            {
                return NotFound("Not Found");
            }
            else
            {
                context.Product.Remove(productt);
                context.SaveChanges();
                return Ok("removed successfully") ;
            }
        }


        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            return Ok(productt);
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            List<Product> products = context.Product.ToList();
            return Ok(products);

        }


        [HttpGet("GetByname")]
        public IActionResult GetByname(string name)
        {
            List<Product> products = context.Product.Where(p=>p.ProductName.Contains( name)).ToList();
            return Ok(products);
        }


        [HttpPatch("UpdateProductPrice")]
        public IActionResult UpdateProductPrice(int id,decimal newPrice)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price = newPrice;
            context.SaveChanges();
            return Ok();
        }


        [HttpPatch("UpdateProductname")]
        public IActionResult UpdateProductname(int id, string name)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.ProductName = name;
            context.SaveChanges();
            return Ok();
        }



        [HttpPut("updateProduct")]
        public IActionResult updateProduct(int id, Product newproduct)
        {
            Product productt = context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price=newproduct.Price;
            productt.ProductName = newproduct.ProductName;
            productt.ProductDescription = newproduct.ProductDescription;
            context.SaveChanges();
            return Ok();


        }



    }
}
