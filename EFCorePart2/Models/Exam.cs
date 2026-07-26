using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
