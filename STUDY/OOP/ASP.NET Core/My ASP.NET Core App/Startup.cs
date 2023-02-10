using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using My_ASP.NET_Core_App.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_ASP.NET_Core_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register IStudent Class with the specific Student Type.
            //If we want to replace MathStudent class with ScienceStudent class in the future, we just need to replace it
            // in the service registered (in just one place) like this:
            //services.AddSingleton<IStudent,ScienceStudent>(); so all controller in the app start using ScienceStudents instead of MathStudent,
            //without any modifications in the Controllers. 

            services.AddSingleton<IStudent,MathStudent>();
            //enabling use of session.

            services.AddSession();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My_ASP.NET_Core_App", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                //All these methods bellow are middleware compoents parts of our Request Pipelines. Every time a request is made over the server,
                //all of them will be excecuted in the same sequence they were defined. 
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My_ASP.NET_Core_App v1"));
            }

            else {

                    app.UseExceptionHandler("/Error");
           
            
            }
            //enabling use of session.
            app.UseSession();

            app.UseCustomMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });
            //Request Delegate.(USE, RUN, MAP)

            app.Use(async(context,next) =>
            {
                await context.Response.WriteAsync("Hello from 1 request delegate. ");
                await next();
            });
            //Map: Map as the name suggests. It basically maps to a path and creates a branch for the request pipeline which matches the path.
            app.Map("/auth", a =>
            {
                a.Run(async (context) =>
                {
                    await context.Response.WriteAsync("New Branch for /Auth");
                });

            });
            app.Run(async(context) =>
             {
                 await context.Response.WriteAsync("Hellow from 2 request delegate.");
             });
          
        }
    }
}
