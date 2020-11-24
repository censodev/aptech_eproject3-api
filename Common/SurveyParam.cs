using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SurveyParam
    {
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public string OrderBy { get; set; }
        public string Order { get; set; }
        public string Keyword { get; set; }
        public int? Status { get; set; } = null;
        public long? DoneBy { get; set; } = null;
    }
}
