using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCoreWebApi.IService;
using NetCoreWebApi.Service;
using NetCoreWebApi.Common;
using NetCoreWebApi.Common.DBContext;
using System.Reflection;
using System.IO;
using NetCoreWebApi.Model.AutoMapper;
using AutoMapper;

namespace NetCoreWebApi
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
            services.AddControllers();
            //·þÎñ×¢²á
            services.AddScoped<IOrderService, OrderService>();
            //×¢²ásqlsugar
            services.AddDBContext(Configuration.GetConnectionString("DB"));
            //swaggerÅäÖÃ
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = ".NetCoreSwagger",
                    Description = "¸öÈË²âÊÔ",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "huahua"
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //s.IncludeXmlComments(xmlPath);
                var xml_path = Path.Combine(AppContext.BaseDirectory, "NetCoreWebApi.xml");
                var xml_path_model = Path.Combine(AppContext.BaseDirectory, "NetCoreWebApi.Model.xml");
                s.IncludeXmlComments(xml_path, true);
                s.IncludeXmlComments(xml_path_model);
            });
            //×¢²áAutoMapper
            services.AddAutoMapper(new Type[] { typeof(OrderMapperProfile), typeof(BatchMapperProfile) });
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                s.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
