using Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Repositories
{
    public class SurveyResultRepository : Repository<SurveyResult>, ISurveyResultRepository
    {
        public SurveyResultRepository(DataContext context, ILogger<SurveyResultRepository> logger) : base(context, logger)
        {
        }

        public IEnumerable<SurveyResult> FindBySurveyId(long surveyId)
        {
            return context.SurveyResults.Where(r => r.Survey.Id.Equals(surveyId)).ToList();
        }

        public IEnumerable<SurveyResult> FindByUserDone(long userId)
        {
            return context.SurveyResults.Where(r => r.User.Id.Equals(userId)).ToList();
        }
    }
}
