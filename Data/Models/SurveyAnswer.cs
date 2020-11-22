using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SurveyAnswer : Entity
    {
        public int Number { get; set; }
        public int Answer { get; set; }
    }
}
