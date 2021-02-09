using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using DotnetMVC.Entities;

namespace DotnetMVC
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration
        {
            get;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DotNetMVCDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Token", "RefreshToken"));
            }

            );
            services.AddControllers();
            services.AddSwaggerGen(c =>
          {
              c.EnableAnnotations();
              var version = Assembly.GetEntryAssembly().GetName().Version;
              var apiBuildNumber = $"{version.Major}.{version.Minor}.{version.Revision}";
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dotnet REST API", Version = "v1", Description = $"<strong>Build #: </strong> {apiBuildNumber}" });
              var xmlFile = $"\\wwwroot\\documentation.xml";
              var xmlPath = _env.ContentRootPath + xmlFile;
              c.IncludeXmlComments(xmlPath);
          }

          );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ///app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(_ => true));
            app.UseRouting();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            ///app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.EnableDeepLinking();
                c.DisplayRequestDuration();
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BurganBank REST API'S V1");
                    c.RoutePrefix = string.Empty;
                }
                else
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Burgan Bank REST API'S V1");
                    c.RoutePrefix = string.Empty;
                }
            }

            );
        }
       
    }
}
