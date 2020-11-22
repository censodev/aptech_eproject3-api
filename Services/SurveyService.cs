using Common.Requests;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository surveyRepository;
        private readonly IUserRepository userRepository;

        public SurveyService(ISurveyRepository surveyRepository,
                             IUserRepository userRepository)
        {
            this.surveyRepository = surveyRepository;
            this.userRepository = userRepository;
        }

        public bool Create(SurveyRequest request)
        {
            return surveyRepository.Add(new Data.Models.Survey()
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = 1,
                User = userRepository.Find(request.UserId),
                Questions = request.Questions.Select(q => new Data.Models.SurveyQuestion()
                {
                    Number = q.Number,
                    Question = q.Question,
                    Answer = q.Answer,
                    Options = q.Options.Select(opt => new Data.Models.QuestionOption()
                    {
                        Title = opt.Title,
                        Value = opt.Value,
                    }),
                    Status = 1,
                }),
            });
        }
    }
}
