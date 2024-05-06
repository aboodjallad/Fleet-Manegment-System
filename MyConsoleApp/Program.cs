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

             /*ConcurrentDictionary<string, string> x = new ConcurrentDictionary<string, string>
             {
                 ["drivername"] = "abood",
                 ["phonenumber"] = "0595793983"
             };
             GVAR gvar = new GVAR();
             gvar.DicOfDic.TryAdd("Drivers", x);
             var w = new DriverServices();
             var drivers = w.GetDrivers();
             //PrintConcurrentDictionary(drivers);
             foreach(var dt in drivers.DicOfDT)
            {
                Console.WriteLine(dt.Key);

            }
             */
            //PrintConcurrentDictionary(drivers);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void PrintConcurrentDictionary(GVAR dictionary)
        {
            foreach (var kvp in dictionary.DicOfDT)
            {
                Console.WriteLine($"Table Key: {kvp.Key}");
                PrintDataTable(kvp.Value);
            }
        }

        public static void PrintDataTable(DataTable table)
        {
            Console.WriteLine($"Contents of {table.TableName}:");
            // Print the column names
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }
            Console.WriteLine();

            // Print each row data
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }




        public static void InspectGvarClass()
        {
            Type gvarType = typeof(GVAR); // Make sure GVAR is correctly referenced here
            Console.WriteLine($"Inspecting {gvarType.Name}");

            // List properties
            Console.WriteLine("Properties:");
            foreach (var prop in gvarType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine($" - {prop.Name} ({prop.PropertyType.Name})");
            }

            // List methods
            Console.WriteLine("Methods:");
            foreach (var method in gvarType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                Console.WriteLine($" - {method.Name} ({string.Join(", ", method.GetParameters().Select(p => p.ParameterType.Name + " " + p.Name))})");
            }
        }

        
        public static void Run(GVAR gvar)
        {
            if (gvar.DicOfDic != null && !gvar.DicOfDic.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDic");
            }
            else if (gvar.DicOfDT != null && !gvar.DicOfDT.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDT");
            }
            else
            {
                Console.WriteLine("GVAR is empty or not properly initialized.");
            }
        }
    }
}
