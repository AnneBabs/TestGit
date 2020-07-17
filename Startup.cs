using System;
using EmailService.Interface;
using EmailService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;

namespace EmailService
{


    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      
        public IConfiguration Configuration { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserServices>();
            services.AddTransient<IEmailService, EmailServices>();
            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Email API",
                    Version = "v1",
                    Description = "An email sender API",
                    TermsOfService = new Uri("https://github.com/AnneBabs/TestGit"),
                    Contact = new OpenApiContact
                    {
                        Name = "Anne Babawale",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/AnneBabs/TestGit"),

                    },

                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSerilogRequestLogging();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Email API V1");
                c.RoutePrefix = string.Empty;

            });
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
