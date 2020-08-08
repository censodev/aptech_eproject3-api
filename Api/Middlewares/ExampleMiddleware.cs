using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate next;

        public ExampleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // do somethings
            await next(context);
        }
    }
}
