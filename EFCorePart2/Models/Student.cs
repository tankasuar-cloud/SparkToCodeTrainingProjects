    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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


            // Belongs
            [ForeignKey("Department")]
            public int DepartmentId { get; set; }
            public Department Department { get; set; }

            // Lives in
            [ForeignKey("Hostel")]
            public int? HostelId { get; set; }
            public Hostel Hostel { get; set; }

            // Takes
             public List<Enrolls> Enrolls { get; set; }

            // Takes
            public List<Takes> Takes { get; set; }

            //TeachesSubjects
            public List<TeachesSubject> TeachesSubjects { get; set; }

    }
    }
