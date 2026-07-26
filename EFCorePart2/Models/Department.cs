using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Works in
        public List<Faculity> Faculty { get; set; }

        // Belongs
        public List<Student> Student { get; set; }

    }
}
