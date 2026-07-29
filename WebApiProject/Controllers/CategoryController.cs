using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private readonly Projectcontext _context;

        public CategoryController(Projectcontext context)
        {
            _context = context; // Fixed context assignment
        }


        [HttpPost("addCategory")]
        public IActionResult addCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return Ok(category.CategoryId);
        }


        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            Category category = _context.Category.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return NotFound("Not Found");

            }
            else
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
                return Ok("removed successfully");

            }
        }


        [HttpGet("Getcategory")]
        public IActionResult Getcategory(int id)
        {
            Category category = _context.Category.FirstOrDefault(p => p.CategoryId == id);
            return Ok(category);
        }


        [HttpGet("GetAllcategory")]
        public IActionResult GetAllcategory()
        {
            List<Category> category = _context.Category.ToList();
            return Ok(category);

        }
    }
}
