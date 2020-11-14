using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyQuestion
    {
        [Key]
        public long Id { get; set; }
        public Survey Survey { get; set; }
        public int Number { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Options { get; set; }
    }
}
