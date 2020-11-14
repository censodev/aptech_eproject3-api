using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Faq
    {
        [Key]
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
