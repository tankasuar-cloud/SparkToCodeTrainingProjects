using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        
        private Projectcontext _context;
        public ProductController(Projectcontext context)
        {
            _context = context;
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product p)
        {
            _context.Product.Add(p);
            _context.SaveChanges();
            return Ok(p.ProductId) ;
        }


        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
           Product productt= _context.Product.FirstOrDefault(p => p.ProductId == id);
            if (productt == null )
            {
                return NotFound("Not Found");
            }
            else
            {
                _context.Product.Remove(productt);
                _context.SaveChanges();
                return Ok("removed successfully") ;
            }
        }


        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            Product productt = _context.Product.FirstOrDefault(p => p.ProductId == id);
            return Ok(productt);
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            List<Product> products = _context.Product.ToList();
            return Ok(products);

        }


        [HttpGet("GetByname")]
        public IActionResult GetByname(string name)
        {
            List<Product> products = _context.Product.Where(p=>p.ProductName.Contains( name)).ToList();
            return Ok(products);
        }


        [HttpPatch("UpdateProductPrice")]
        public IActionResult UpdateProductPrice(int id,decimal newPrice)
        {
            Product productt = _context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price = newPrice;
            _context.SaveChanges();
            return Ok();
        }


        [HttpPatch("UpdateProductname")]
        public IActionResult UpdateProductname(int id, string name)
        {
            Product productt = _context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.ProductName = name;
            _context.SaveChanges();
            return Ok();
        }



        [HttpPut("updateProduct")]
        public IActionResult updateProduct(int id, Product newproduct)
        {
            Product productt = _context.Product.FirstOrDefault(p => p.ProductId == id);
            productt.Price=newproduct.Price;
            productt.ProductName = newproduct.ProductName;
            productt.ProductDescription = newproduct.ProductDescription;
            _context.SaveChanges();
            return Ok();


        }



    }
}
