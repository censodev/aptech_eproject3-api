using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ViewModels
{
    public class SurveyUserCountStat
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserCount { get; set; }
    }
}
