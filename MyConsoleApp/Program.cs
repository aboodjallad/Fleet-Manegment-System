using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Fleet_Manegment_System;
using System;
using FPro;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Concurrent;
using Fleet_Manegment_System.Services.Driver;
using System.Data;
namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
