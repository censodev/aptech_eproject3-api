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

        public SumStat SumStat()
        {
            return new SumStat()
            {
                SurveyCount = dataContext.Surveys.Count(),
                UserCount = dataContext.Users.Count(),
                SurveyResultCount = dataContext.SurveyResults.Count(),
            };
        }

        public IEnumerable<SurveyUserCountStat> SurveyUserCountStat()
        {
            var sql = @"select s.Id, s.Title, s.StartDate, s.EndDate, count(sr.Id) UserCount
                        from Surveys s
                        left join SurveyResults sr on s.Id = sr.SurveyId
                        group by s.Id, s.Title, s.StartDate, s.EndDate";
            var query = dataContext.SurveyUserCountStats.FromSqlRaw<SurveyUserCountStat>(sql);
            return query.ToList();
        }
    }
}
