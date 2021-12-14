using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Tilde.MT.TranslationSystemService.Extensions
{
    public static class DocumentationExtensions
    {
        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = nameof(Tilde.MT.TranslationSystemService), Version = "v1" });
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, $"{nameof(Tilde)}.{nameof(Tilde.MT)}.{nameof(Tilde.MT.TranslationSystemService)}.xml"));
            });
            
            return services;
        }

        public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{nameof(Tilde.MT.TranslationSystemService)} v1"));

            return app;
        }
    }
}
