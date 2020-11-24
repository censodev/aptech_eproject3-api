using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyQuestion : Entity
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public int Answer { get; set; }
        public IEnumerable<QuestionOption> Options { get; set; }
    }
}
