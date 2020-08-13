using Api.Providers;
using Data.Repositories;
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
            services.AddScoped<IUserService, UserService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void UseProviders(this IServiceCollection services)
        {
            services.AddSingleton<JwtProvider>();
            services.AddSingleton<BCryptProvider>();
        }
    }
}
