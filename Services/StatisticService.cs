using Common.ViewModels;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class StatisticService : IStatisticService
    {
        private DataContext dataContext;

        public StatisticService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public SummaryStat SummaryStat()
        {
            var sql = "";
            //dataContext.SurveyAnswers.FromSqlRaw<SummaryStat>(sql);
            return null;
        }
    }
}
