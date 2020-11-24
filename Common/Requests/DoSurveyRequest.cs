using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Requests
{
    public class DoSurveyRequest
    {
        public long SurveyId { get; set; }
        public long UserId { get; set; }
        public IEnumerable<DoSurveyAnswerRequest> Answers { get; set; }
    }

    public class DoSurveyAnswerRequest
    {
        public int Number { get; set; }
        public int Answer { get; set; }
    }
}
