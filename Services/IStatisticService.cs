using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IStatisticService
    {
        IEnumerable<SurveyUserCountStat> SurveyUserCountStat();
        SumStat SumStat();
    }
}
