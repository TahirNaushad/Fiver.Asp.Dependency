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
        private readonly IGreetingService greetingService;

        public HelloWorldMiddleware(
            RequestDelegate next, 
            IGreetingService greetingService)
        {
            this.next = next;
            this.greetingService = greetingService;
        }

        public async Task Invoke(HttpContext context)
        {
            var message = greetingService.Greet("World (via DI)");
            await context.Response.WriteAsync(message);
        }
    }
}
