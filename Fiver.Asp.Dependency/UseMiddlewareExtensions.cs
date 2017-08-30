using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Fiver.Asp.Dependency
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }

        public static IApplicationBuilder UseHelloDevelopers(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloDevelopersMiddleware>();
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

    public class HelloDevelopersMiddleware
    {
        private readonly RequestDelegate next;

        public HelloDevelopersMiddleware(
            RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(
            HttpContext context)
        {
            var greetingService = context.RequestServices.GetService<IGreetingService>();
            var message = greetingService.Greet("Developers (via GetService)");
            await context.Response.WriteAsync(message);
        }
    }
}
