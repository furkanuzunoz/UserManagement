using UserManagement.BusinesLayer.Concrete;
using UserManagement.BusinesLayer.Interface;
using UserManagement.DataAccesLayer;
using UserManagement.DataAccesLayer.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using System.Reflection;
using AutoMapper;

namespace UserManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string deneme = "mydenemestringfelanfilan";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           /* services.AddCors(options =>
            {
                options.AddPolicy("mydenemestringfelanfilan",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            });*/
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserManagement.Api", Version = "v1" });
            });
            services.AddScoped<IDbOperations, DbOperations>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserManagement.Api v1"));
            }
            app.UseCors(options => options.WithOrigins("https://localhost:44367").AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
