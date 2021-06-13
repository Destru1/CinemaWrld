using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CinemaWrld.Application.Infrastructure.Middlewares
{
    public class GlobalExeptionMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExeptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {

                context.Response.Redirect("/home/error");
            }
        }
    }
}
