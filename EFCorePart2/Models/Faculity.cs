using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    public class Faculity
    {
        [Key]
        public int F_id { get; set; }
        public String Name { get; set; }
        public int Mobile_no { get; set; }
        public double Salary { get; set; }


        // Works in
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } 


    }
}
