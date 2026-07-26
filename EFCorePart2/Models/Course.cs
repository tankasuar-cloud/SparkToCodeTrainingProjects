using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCorePart2.Models
{
    internal class Course
    {
        [Key]
        public int Course_id { get; set; }
        public string course_name { get; set; }
        public  int duration { get; set; }

    }
}
