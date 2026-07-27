using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_Commerce.Models
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        
        public int Quantity { get; set; }
    }
}
