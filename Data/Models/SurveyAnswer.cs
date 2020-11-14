using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyAnswer : Entity
    {
        public SurveyResult SurveyResult { get; set; }
        public int Number { get; set; }
        public string Answer { get; set; }
    }
}
