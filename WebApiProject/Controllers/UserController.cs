using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private Projectcontext _context;
        public UserController(Projectcontext context)
        {
            _context = context;
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User U)
        {
            _context.User.Add(U);
            _context.SaveChanges();
            return Ok(U.UserId);
        }



        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            User Userr = _context.User.FirstOrDefault(p => p.UserId == id);
            if (Userr == null)
            {
                return NotFound("Not Found");
            }
            else
            {
                _context.User.Remove(Userr);
                _context.SaveChanges();
                return Ok("removed successfully");

            }
        }



        [HttpGet("GetUser")]
        public IActionResult GetUser(int id)
        {
            User Userr = _context.User.FirstOrDefault(p => p.UserId == id);
            return Ok(Userr);
        }



        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<User> Userr = _context.User.ToList();
            return Ok(Userr);

        }



        [HttpGet("GetByname")]
        public IActionResult GetByname(string name)
        {
            List<User> Userr = _context.User.Where(p => p.FullName.Contains(name)).ToList();
            return Ok(Userr);
        }


        [HttpPatch("UpdateUserPassword")]
        public IActionResult UpdateUserPassword(int id, string password)
        {
            User Userr = _context.User.FirstOrDefault(p => p.UserId == id);
            if (password == Userr.Password)
            {
                return BadRequest("Cannot use the same password");
            }
            else
            {
                Userr.Password = password;
                _context.SaveChanges();
                return Ok();
            }
            
        }
    }
}
