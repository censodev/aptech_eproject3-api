using Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ISurveyService
    {
        bool Create(SurveyRequest request);
    }
}
