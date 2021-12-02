using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using NorthwindService.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http; // GetEndpoint() extension method
using Microsoft.AspNetCore.Routing;

namespace NorthwindService
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
            string databasePath = Path.Combine("..", "Northwind.db");
            // Cross-Origin Resource Sharing(CORS)
            services.AddCors();
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data Source={databasePath}"));
            services.AddControllers(options =>
            {
                WriteLine("Default output formatters:");
                foreach (IOutputFormatter formatter in options.OutputFormatters)
                {
                    var mediaFormatter = formatter as OutputFormatter;

                    if (mediaFormatter == null)
                    {
                        WriteLine($" {formatter.GetType().Name}");
                    }
                    else  // OutputFormatter class has SupportedMediaTypes
                    {
                        WriteLine(" {0}, Media types: {1}", mediaFormatter.GetType().Name, string.Join(",", mediaFormatter.SupportedMediaTypes));
                    }
                }
            }
            )
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // Register CustomerRepository for using it in the runtime
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // register the swagger generator and define a swagger document for northwind service
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: "v1", info: new OpenApiInfo
                {
                    Title = "Northwind Service API",
                    Version = "V1"
                });
            });
            services.AddHealthChecks().AddDbContextCheck<Northwind>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // after UseRouting and before UseEndpoints
            app.UseCors(configurePolicy: options =>
            {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins("https://localhost:44379");  // for MVC client
            });

            app.Use(next => (context) =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint != null)
                {
                    WriteLine("*** Name: {0}; Route: {1}; Metadata: {2}", endpoint.DisplayName,
                        (endpoint as RouteEndpoint)?.RoutePattern, string.Join(", ", endpoint.Metadata));
                }

                // pass context to next middleware in pipeline
                return next(context);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHealthChecks(path: "/howdoyoufeel");

            // use Swagger and SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind Service API Version 1");
                options.SupportedSubmitMethods(new[]
                {
                    SubmitMethod.Get,SubmitMethod.Post,SubmitMethod.Put,SubmitMethod.Delete
                });
            });
        }
    }
}
