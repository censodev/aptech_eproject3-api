using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyQuestion : Entity
    {
        public long SurveyId { get; set; }
        //public Survey Survey { get; set; }
        public int Number { get; set; }
        public string Question { get; set; }
        public int Answer { get; set; }
        public IEnumerable<QuestionOption> Options { get; set; }
    }
}
