using WebApiProject.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApiProject.Controllers
{
    public class CategoryController
    {
        private Projectcontext context;
        public CategoryController(Projectcontext context)
        {
            context = context;
        }
        public void addCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }
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
    }
}
