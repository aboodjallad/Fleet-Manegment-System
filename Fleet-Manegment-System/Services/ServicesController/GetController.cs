using Fleet_Manegment_System.Services.Driver;
using Fleet_Manegment_System.Services.General;
using Fleet_Manegment_System.Services.Vehicle;
using System.Collections.Concurrent;
using System.Data;
using FPro;


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
                    ConcurrentDictionary<string, string>? newDictionary = dicService.GetDicOfDic(dictionary);
                    try
                    {
                        result.DicOfDic.TryAdd(key,newDictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");

                    }
                }
                else if (dic.Key == "Vehicles")
                {
                    var key = dic.Key;
                    dicService = new VehicleServices();
                    ConcurrentDictionary<string, string>? newDictionary = dicService.GetDicOfDic(dictionary);
                    try
                    {
                        result.DicOfDic.TryAdd(key, newDictionary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");

                    }
                }
            }
            Send(result);
            Console.WriteLine(skippedCounter + " Dictionarys are skipped\n");
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
                    var key = dt.Key;
                    var table = dt.Value;
                    dtService = new VehicleServices();
                    DataTable? newDataTable = dtService.GetDicOfDT(table, key);
                    try
                    {
                        result.DicOfDT.TryAdd(key, newDataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");

                    }
                }
            }
            Send(result);
            Console.WriteLine(skippedCounter + " tabels are skipped\n");

        }//done
    }
}
