using MANUAL.API.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MANUAL.API.Domain.Repository;
using MANUAL.API.Data.Repositorires;
using MANUAL.API.Mapping;

namespace MANUAL.API
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
            var _AppConnString = Configuration.GetConnectionString("Test_ManualAPIContext");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetRestApiCore", Version = "v1" });
            });
            
            services.AddDbContext<ManualAPIDBContext>( options =>
                    options.UseSqlServer(_AppConnString).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

            //Adding the Unity of work to the DI Continer.

            services.AddScoped<IUnityOfWork, UnityOfWork>();
            
            //Adding Repositories to DI Container.

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Register AutoMapper in my DI Container for dependency Injection.

            services.AddAutoMapper(c => c.AddProfile<AutoMappingProfile>(),typeof(Startup));
        

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MANUAL.API v1"));
            }
            else
            {   //security feauture
                //This method tell a browser when we return a response to use HTTPS 
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                //Cors Policy defination.
                //for now we are allowing all origins
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ManualAPIDBContext>().Database.Migrate();
            }
        }
    }
}
