using Microsoft.AspNetCore.Http;
using MyRecipes.Common.Models;
using MyRecipes.Common.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyRecipes.Custom
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogService logService)
        {
            var requestLog = JsonConvert.SerializeObject(new { RequestPath = httpContext.Request.Path  });
            var requestLogData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = requestLog };
            logService.Log(requestLogData);

            await _next(httpContext);
            
            var responseLog = JsonConvert.SerializeObject(new { ResponseStatusCode = httpContext.Response.StatusCode.ToString() });
            var responseLogData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = responseLog };
            logService.Log(responseLogData);
        }
    }
}
