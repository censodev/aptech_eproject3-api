using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyAnswer
    {
        [Key]
        public long Id { get; set; }
        public SurveyResult SurveyResult { get; set; }
        public int Number { get; set; }
        public string Answer { get; set; }
    }
}
