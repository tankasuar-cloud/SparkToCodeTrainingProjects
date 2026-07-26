using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    [PrimaryKey(nameof(F_id), nameof(SubjectID), nameof(S_id))]
    public class TeachesSubject
    {
        [ForeignKey("Faculity")]
        public int F_id { get; set; }
        public Faculity Faculity { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey("Student")]
        public int S_id { get; set; }
        public Student Student { get; set; }


    }
}
