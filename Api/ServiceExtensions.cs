﻿using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class ServiceExtensions
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IStatisticService, StatisticService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<ISurveyResultRepository, SurveyResultRepository>();
        }
    }
}
