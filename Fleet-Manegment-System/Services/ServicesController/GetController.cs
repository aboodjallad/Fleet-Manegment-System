using FPro;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class GetController : IRun
    {
        static private GVAR Send(GVAR gvar)
        {
            return gvar;
        }
        public override void HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
        {
            IDicOfDic dicService;
            GVAR result = new();
            int skippedCounter = 0;

            foreach (var dic in dicOfDic)
            {
                var dictionary = dic.Value;
                if (dictionary == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dic.Key == "Driver")
                {
                    var key = dic.Key;
                    dicService = new DriverServices();
                    ConcurrentDictionary<string, string>? newDictionary = dicService.GetDicOfDic(dictionary,key);
                    try
                    {
                        result.DicOfDic.TryAdd(key,newDictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");

                    }
                }
            }
            Send(result);
        }//done

        public override void HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            IDicOfDT dtService;
            int skippedCounter = 0;
            GVAR result = new();
            foreach (var dt in dicOfDT)
            {
                if (dt.Key == null)
                {
                    Console.WriteLine("Data Table Key cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dt.Key == "Drivers")
                {
                    var key = dt.Key;
                    var table = dt.Value;
                    dtService = new DriverServices();
                    DataTable? newDataTable = dtService.GetDicOfDT(table, key);
                    try
                    {
                        result.DicOfDT.TryAdd(key, newDataTable);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");

                    }
                }
                else if (dt.Key == "Vehicles")
                {
                    // Assuming a method to handle vehicle data
                }
            }
            Send(result);
        }//done
    }
}
