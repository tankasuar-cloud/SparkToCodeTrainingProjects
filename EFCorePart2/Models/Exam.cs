using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    public class Exam
    {
        [Key]
        public int ExamCode { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string room { get; set; }



        // Conducts
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        // Enroll
        public List<Enrolls> Enrolls { get; set; }
    }
}
