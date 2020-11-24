using Common;
using Common.Requests;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISurveyService
    {
        bool Create(SurveyRequest request);
        IEnumerable<Survey> List(SurveyParam param);
        Survey One(long id);
        bool Update(SurveyRequest request);
        SurveyResult DoSurvey(DoSurveyRequest request);
    }
}
