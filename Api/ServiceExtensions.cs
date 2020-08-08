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
            services.AddScoped<IExampleService, ExampleService>();
        }
    }
}
