using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }


        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
