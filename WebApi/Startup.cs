using BusinessLayer;
using DataLayer.CurrencyServices;
using DataLayer.DataProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StubGenerator;
using System;

namespace WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            
            var updateMock = true;

            if (updateMock)
            {
                CreatorStubFile.Init();
            }

            // Закрываем интерфейс моком если переменная среды MockDataLayer
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "MockDataLayer")
            {
                services.AddScoped<IDataProvider, FileDataProvider>();
            }
            else
            {
                services.AddScoped<IDataProvider, InMemoryDataProvider>();
            }

            services.AddScoped<ProductService>();
            services.AddScoped<ICurrenceExchange, Mig>();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "MockDataLayer")
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

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
