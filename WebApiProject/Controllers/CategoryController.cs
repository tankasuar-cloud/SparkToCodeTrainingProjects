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
        public void addCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }


        [HttpDelete("DeleteProduct")]
        public void DeleteProduct(int id)
        {
            Category category = context.Category.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {

            }
            else
            {
                context.Category.Remove(category);
                context.SaveChanges();
            }
        }


        [HttpGet("Getcategory")]
        public Category Getcategory(int id)
        {
            Category category = context.Category.FirstOrDefault(p => p.CategoryId == id);
            return category;
        }


        [HttpGet("GetAllcategory")]
        public List<Category> GetAllcategory()
        {
            List<Category> category = context.Category.ToList();
            return category;

        }
    }
}
