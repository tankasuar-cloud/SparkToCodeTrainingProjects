using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class Order
    {
        [Key]
        [JsonIgnore]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; };
    }
}
