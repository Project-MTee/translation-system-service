using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using Tilde.MT.TranslationSystemService.Extensions;
using Tilde.MT.TranslationSystemService.Models.Configuration;
using Tilde.MT.TranslationSystemService.Models.Mappings;

namespace Tilde.MT.TranslationSystemService
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
            var configurationSettings = Configuration.GetSection("Configuration").Get<ConfigurationSettings>();
            services.Configure<ConfigurationSettings>(Configuration.GetSection("Configuration"));

            services.AddCorsPolicies();

            services.AddControllers();

            services.AddDocumentation();

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            app.UseDeveloperExceptionPage();
            app.UseDocumentation();
#endif

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
#if DEBUG
            app.UseCorsPolicies();
#endif

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Disposition", "attachment; filename=\"api.json\"");
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Startup probe / readyness probe
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {

                });

                // Liveness 
                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {

                });
            });
        }
    }
}
