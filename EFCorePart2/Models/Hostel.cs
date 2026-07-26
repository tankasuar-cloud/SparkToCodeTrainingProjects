using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePart2.Models
{
    public class Hostel
    {
        [Key]
        public int HostelId { get; set; }
        public string HostelName { get; set; }
        public int nomberOfSeats { get; set; }
        public string pinCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }

    }
}
