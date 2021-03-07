using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Itau.Teste.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string porta = Environment.GetEnvironmentVariable("PORT");

            if (string.IsNullOrWhiteSpace(porta))
            {
                return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSetting("https_port", "5001");
                    //webBuilder.UseSetting("http_port", "8001");
                    webBuilder.UseStartup<Startup>();
                });
            }
            else
            {
                return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSetting("https_port", "5001");
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://*:{porta}");
                });
            }
        }
    }
}
