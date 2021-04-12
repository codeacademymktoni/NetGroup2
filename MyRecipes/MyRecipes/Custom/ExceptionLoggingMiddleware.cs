using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MyRecipes.Common.Services;
using MyRecipes.Common.Models;

namespace MyRecipes.Custom
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var logData = new LogData() { Type = LogType.Error, DateCreated = DateTime.Now, Message = ex.ToString() };
                logService.Log(logData);

                throw;
            }
        }
    }
}
