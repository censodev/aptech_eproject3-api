using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface ISurveyResultRepository : IRepository<SurveyResult>
    {
        IEnumerable<SurveyResult> FindByUserDone(long userId);
        IEnumerable<SurveyResult> FindBySurveyId(long surveyId);
    }
}
