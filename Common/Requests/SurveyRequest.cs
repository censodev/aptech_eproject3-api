using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Requests
{
    public class SurveyRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<SurveyQuestionRequest> Questions { get; set; }
        public int Status { get; set; }
    }

    public class SurveyQuestionRequest
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string Question { get; set; }
        public int Answer { get; set; }
        public IEnumerable<SurveyQuestionOptionRequest> Options { get; set; }
        public int Status { get; set; }
    }

    public class SurveyQuestionOptionRequest
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
    }
}
