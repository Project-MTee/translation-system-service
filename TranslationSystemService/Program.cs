using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System.IO;
using Tilde.MT.TranslationSystemService.Models.Configuration;
using Tilde.MT.TranslationSystemService.Models.Mappings;

const string DevelopmentCorsPolicy = "development-policy";

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Debug()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

var configurationSettings = builder.Configuration.GetSection("Configuration").Get<ConfigurationSettings>();
var mappingConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new MappingProfile());
}); 
builder.Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("Configuration"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: DevelopmentCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200").AllowAnyHeader();
        }
    );
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "TranslationSystemService", 
        Version = "v1" 
    });
    config.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, $"{nameof(Tilde)}.{nameof(Tilde.MT)}.{nameof(Tilde.MT.TranslationSystemService)}.xml"));
});
builder.Services.AddSingleton(mappingConfig.CreateMapper());
builder.Host.UseSerilog();

var app = builder.Build();

#if DEBUG
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseRouting();

#if DEBUG
app.UseCors(DevelopmentCorsPolicy);
#endif
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
