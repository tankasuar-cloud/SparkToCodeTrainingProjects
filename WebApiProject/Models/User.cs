using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
