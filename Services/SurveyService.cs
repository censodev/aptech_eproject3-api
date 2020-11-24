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
        private readonly ISurveyResultRepository surveyResultRepository;
        private readonly IUserRepository userRepository;

        public SurveyService(ISurveyRepository surveyRepository,
                             IUserRepository userRepository,
                             ISurveyResultRepository surveyResultRepository)
        {
            this.surveyRepository = surveyRepository;
            this.userRepository = userRepository;
            this.surveyResultRepository = surveyResultRepository;
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

        public SurveyResult DoSurvey(DoSurveyRequest request)
        {
            var isExist = surveyResultRepository.Context.SurveyResults
                .Where(r => r.Survey.Id.Equals(request.SurveyId))
                .Where(r => r.User.Id.Equals(request.UserId))
                .Count() > 0;

            if (isExist)
            {
                return null;
            }

            var result = new SurveyResult()
            {
                Status = 1,
                CreatedAt = DateTime.Now,
                Survey = surveyRepository.Find(request.SurveyId),
                User = userRepository.Find(request.UserId),
                Answers = request.Answers.Select(asw => new SurveyAnswer()
                {
                    Status = 1,
                    Number = asw.Number,
                    Answer = asw.Answer,
                }).ToList(),
                Mark = Math.Round((float) surveyRepository.Context.Surveys
                    .Where(s => s.Id.Equals(request.SurveyId))
                    .Include(s => s.Questions)
                    .FirstOrDefault()
                    .Questions
                        .Aggregate(0, (acc, cur) =>
                        {
                            var rs = request.Answers
                                .Where(asw => asw.Number.Equals(cur.Number))
                                .Where(asw => asw.Answer.Equals(cur.Answer))
                                .Count();
                            return acc + rs;
                        }) / request.Answers.Count() * 100, 2),
            };

            if (!surveyResultRepository.Add(result))
            {
                return null;
            }

            return result;
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

            if (param.Status != null)
            {
                query = query.Where(s => s.Status.Equals(param.Status));
            }

            if (param.DoneBy != null)
            {
                var results = surveyResultRepository.FindByUserDone((long) param.DoneBy)
                    .Select(r => r.Survey.Id).ToArray();
                query = query.Where(s => results.Contains(s.Id));
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
