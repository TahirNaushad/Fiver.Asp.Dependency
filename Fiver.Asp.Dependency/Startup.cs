using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Asp.Dependency
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            //services.AddScoped<IGreetingService, GreetingService>();

            //services.AddScoped<IGreetingService>(factory =>
            //{
            //    return new FlexibleGreetingService("Good Morning");
            //});

            services.AddSingleton<IGreetingService>(
                new FlexibleGreetingService("Good Evening"));
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseHelloWorld();
        }
    }
}
