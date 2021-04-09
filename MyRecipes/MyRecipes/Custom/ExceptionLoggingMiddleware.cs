using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyRecipes.Custom
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //customer logic for http context
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
