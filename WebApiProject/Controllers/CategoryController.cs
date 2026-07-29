using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private Projectcontext context;
        public CategoryController(Projectcontext context)
        {
            context = context;
        }


        [HttpPost("addCategory")]
        public IActionResult addCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return Ok(category.CategoryId);
        }


        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            Category category = context.Category.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return NotFound("Not Found");

            }
            else
            {
                context.Category.Remove(category);
                context.SaveChanges();
                return Ok("removed successfully");

            }
        }


        [HttpGet("Getcategory")]
        public IActionResult Getcategory(int id)
        {
            Category category = context.Category.FirstOrDefault(p => p.CategoryId == id);
            return Ok(category);
        }


        [HttpGet("GetAllcategory")]
        public IActionResult GetAllcategory()
        {
            List<Category> category = context.Category.ToList();
            return Ok(category);

        }
    }
}
