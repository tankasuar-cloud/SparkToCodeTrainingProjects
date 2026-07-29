using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrderController : ControllerBase
    {
        
        private Projectcontext _context;
        public OrderController(Projectcontext context)
        {
            _context = context;
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            var userExists = _context.User.Any(u => u.UserId == order.UserId);
            if (!userExists)
            {
                return BadRequest("Invalid UserId. User does not exist.");
            }

            if (order.OrderDate == default)
            {
                order.OrderDate = DateTime.Now;
            }

            _context.Order.Add(order);
            _context.SaveChanges();

            return Ok(order.OrderId);
        }

        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Order.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound("Order not found");
            }

            _context.Order.Remove(order);
            _context.SaveChanges();
            return Ok("Order removed successfully");
        }


        [HttpGet("GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Order.Include(o => o.User).FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }



        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Order.Include(o => o.User).ToList();
            return Ok(orders);
        }



        [HttpGet("GetOrdersByUserId")]
        public IActionResult GetOrdersByUserId(int userId)
        {
            var orders = _context.Order.Where(o => o.UserId == userId).ToList();
            return Ok(orders);
        }
    }
}
