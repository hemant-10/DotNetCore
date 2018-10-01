using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //you have to register IGreeter
            services.AddSingleton<IGreeter, Greeting>();
            services.AddMvc();
        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration,
            IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {

                //this is to know the developer exception track record
                app.UseDeveloperExceptionPage();
            }
            // To Use static files for displaying in the view
            app.UseMvc(ConfigureRoutes);
            app.Run(async (context) =>
            {
                // throw new Exception("excpeton");
                //var greeting = configuration["Greeting"];
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Home/Index/1
            routeBuilder.MapRoute("Default", "{controller=Login}/{action=Index}/{id?}");
           
            
        }
    }
}
