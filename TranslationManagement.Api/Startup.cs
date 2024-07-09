using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TranslationManagement.Api.Controllers;
using TranslationManagement.Infrastructure;
using TranslationManagement.Application.Common;
using TranslationManagement.Application.Jobs;
using TranslationManagement.Infrastructure.Repositories;
using System.Reflection;
using System.Collections.Generic;
using TranslationManagement.Domain.Entities;
using TranslationManagement.Application.Common.FileProcessors;
using TranslationManagement.Application.Jobs.UseCases;
using TranslationManagement.Application.Translators;

namespace TranslationManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<FileProcessorFactory>();
            services.AddScoped<IFileProcessor, TextFileProcessor>();
            services.AddScoped<IFileProcessor, XmlFileProcessor>();
            services.AddScoped<IJobsRepository, JobsRepository>();
            services.AddScoped<ITranslatorsRepository, TranslatorsRepository>();
            services.AddTransient<IJobService, JobService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetJobs).Assembly));
            services.AddAutoMapper(GetAppAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationManagement.Api", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=TranslationAppDatabase.db"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private IEnumerable<Assembly> GetAppAssemblies()
        {
            yield return typeof(Program).Assembly;
            yield return typeof(TranslationJob).Assembly;
        }
    }
}
