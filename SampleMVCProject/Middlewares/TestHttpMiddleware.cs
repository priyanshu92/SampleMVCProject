using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SampleMVCProject.Middlewares
{
    public class TestHttpMiddleware
    {
        // Must have constructor with this signature, otherwise exception at run time
        public TestHttpMiddleware(RequestDelegate next)
        {
            // This is an HTTP Handler, so no need to store next
        }

        public async Task Invoke(HttpContext context)
        {
            string response = GenerateResponse(context);

            context.Response.ContentType = GetContentType();
            await context.Response.WriteAsync(response);
        }

        private string GenerateResponse(HttpContext context)
        {
            string title = context.Request.Query["title"];
            return string.Format("Title of the report: {0}", title);
        }

        private string GetContentType()
        {
            return "text/plain";
        }
    }

    public static class TestHttpMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestHttpMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestHttpMiddleware>();
        }
    }
}
