using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateElections.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CandidateElections
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

            //Enable CORS
            services.AddCors( cors =>
             cors.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
            );
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CandidateElections", Version = "v1" });
            });

            // add Custom context method we with own contex

            services.AddDbContext<CandidateElectionsContext>(options =>
              options.UseNpgsql(Configuration.GetConnectionString("CandidateElectionsContext"))
                     .UseSnakeCaseNamingConvention()
                     .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                     .EnableSensitiveDataLogging()
            );

            //We can also add the following service configuration to have the app display detailed error pages when something related to the database or migrations goes wrong
            services.AddDatabaseDeveloperPageExceptionFilter();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CandidateElections v1");
                    }
                );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
