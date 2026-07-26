using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    [PrimaryKey(nameof(S_id), nameof(Course_id))]
    public class Enrolls
    {
        [ForeignKey("Student")]
        public int S_id { get; set; }
        public  Student Student { get; set; }



        [ForeignKey("Course")]
        public int Course_id { get; set; }
        public  Course Course { get; set; }
        
    }
}
