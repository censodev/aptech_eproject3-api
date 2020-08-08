using Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class MiddlewareExtensions
    {
        public static void UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExampleMiddleware>();
        }
    }
}
