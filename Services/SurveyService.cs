using Common.Requests;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Common;

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
            return surveyRepository.Add(new Survey()
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
                        Status = 1,
                    }).ToList(),
                    Status = 1,
                }).ToList(),
            });
        }

        public IEnumerable<Survey> List(SurveyParam param)
        {
            var query = surveyRepository.Context.Surveys
                .Include(s => s.User)
                .AsQueryable();

            if (param.Order != null && param.OrderBy != null)
            {
                Func<Survey, dynamic> func = s => s.Id;
                switch (param.OrderBy)
                {
                    case "title":
                        func = s => s.Title;
                        break;
                    case "userName":
                        func = s => s.User.Name;
                        break;
                    case "startDate":
                        func = s => s.StartDate;
                        break;
                    case "endDate":
                        func = s => s.EndDate;
                        break;
                }

                query = param.Order.Equals("asc")
                    ? query.OrderBy(func).AsQueryable()
                    : query.OrderByDescending(func).AsQueryable();
            }

            if (param.StartDate != null)
            {
                query = query.Where(s => s.StartDate >= param.StartDate);
            }

            if (param.EndDate != null)
            {
                query = query.Where(s => s.EndDate <= param.EndDate);
            }

            if (param.Keyword != null)
            {
                query = query.Where(s => s.Title.Contains(param.Keyword)
                              || s.Description.Contains(param.Keyword)
                              || s.User.Name.Contains(param.Keyword)
                              || s.User.Email.Contains(param.Keyword));
            }

            return query.ToList();
        }

        public Survey One(long id)
        {
            return surveyRepository.Context.Surveys
                .Where(s => s.Id == id)
                .Include(s => s.User)
                .Include(s => s.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefault();
        }

        public bool Update(SurveyRequest request)
        {
            return surveyRepository.Update(new Survey()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = request.Status,
                User = userRepository.Find(request.UserId),
                Questions = request.Questions.Select(q => new SurveyQuestion()
                {
                    Id = q.Id,
                    SurveyId = request.Id,
                    Number = q.Number,
                    Question = q.Question,
                    Answer = q.Answer,
                    Options = q.Options.Select(opt => new QuestionOption()
                    {
                        Id = opt.Id,
                        Title = opt.Title,
                        Value = opt.Value,
                        Status = opt.Status,
                    }).ToList(),
                    Status = q.Status,
                }).ToList(),
            });
        }
    }
}
