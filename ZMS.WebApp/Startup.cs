using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using ZMS.WebApp.Infrastructure;

namespace ZMS.WebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Attach swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ZMS", new Info() { Title = "Core Api", Description = "Swagger Core API" });
            });

            // Find relative path to DB from appsettings.json
            string projectPath = $"{Directory.GetCurrentDirectory()}\\Properties";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appSettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("ConnectionString");

            services.ConfigureServices(connectionString);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/ZMS/swagger.json", "Core Api");
                });
        }
    }
}
