using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    [PrimaryKey(nameof(S_id), nameof(ExamCode))]
    public class Takes
    {
        [ForeignKey("Student")]
        public int S_id { get; set; }
        public virtual Student Student { get; set; }



        [ForeignKey("Exam")]
        public int ExamCode { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
