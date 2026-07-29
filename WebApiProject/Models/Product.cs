using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("_Category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? _Category { get; set; } 
    }
}
    