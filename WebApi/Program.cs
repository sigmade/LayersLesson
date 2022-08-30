using AutocompleteTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApi
{
    public class Program
    {
        private static string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static void Main(string[] args)
        {
            var updateMock = false;

            var host = CreateHostBuilder(args).Build();

            if (updateMock)
            {
                AutoGen.Init();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration(configurationBuilder => 
                {
                    configurationBuilder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{Env}.json", true, true)
                        .AddEnvironmentVariables();
                });
    }
}
