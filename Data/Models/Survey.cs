using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Survey
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
