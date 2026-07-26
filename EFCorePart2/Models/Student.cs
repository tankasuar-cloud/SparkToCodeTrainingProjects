using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCorePart2.Models
{
    public class Student
    {
        [Key]
        public int S_id { get; set; }
        public string F_name { get; set; }
        public string L_name { get; set; }
        public DateTime DOB { get; set; }
        public int phone_number { get; set; }

    }
}
