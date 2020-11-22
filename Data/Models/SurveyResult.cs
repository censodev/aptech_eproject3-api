using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyResult : Entity
    {
        public User User { get; set; }
        public Survey Survey { get; set; }
        public double Mark { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<SurveyAnswer> Answers { get; set; }
    }
}
