using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fiver.Asp.Dependency
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }

    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;

        public HelloWorldMiddleware(
            RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(
            HttpContext context,
            IGreetingService greetingService)
        {
            var message = greetingService.Greet("World (via DI)");
            await context.Response.WriteAsync(message);
        }
    }
}
