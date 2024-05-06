using Fleet_Manegment_System.Services.Driver;
using Fleet_Manegment_System.Services.General;
using Fleet_Manegment_System.Services.Vehichles;
using Fleet_Manegment_System.Services.Vehicle;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class AddController : IRun
    {
        
        public override void HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            IDicOfDT dtService;
            int skippedCounter = 0;
            int doneCounter = 0;

            foreach (var dt in dicOfDT)
            {
                var table = dt.Value;
                if (table == null)
                {
                    Console.WriteLine("table cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dt.Key.Contains("Drivers")) 
                {
                    dtService = new DriverServices();
                    dtService.AddDicOfDT(table);
                    doneCounter += 1;
                }
                else if (dt.Key == "Vehicles")
                {
                    dtService = new VehicleServices();
                    dtService.AddDicOfDT(table);
                    doneCounter += 1;
                }
                else if (dt.Key == "VehiclesInformation")
                {
                    dtService = new VehicleInformation();
                    dtService.AddDicOfDT(table);
                    doneCounter += 1;
                }
            }
            Console.WriteLine(doneCounter + "Tabels added successfully and " + skippedCounter + " are skipped\n");

        }//done

        public override void HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
        {
            IDicOfDic dicService;
            int skippedCounter = 0;
            int doneCounter = 0;

            foreach (var dic in dicOfDic)
            {
                var dictionary = dic.Value;
                if (dictionary == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dic.Key.Contains("Driver"))
                {
                    dicService = new DriverServices();
                    dicService.AddDicOfDic(dictionary);
                    doneCounter += 1;
                }
                else if (dic.Key == "Vehicles")
                {
                    dicService = new VehicleServices();
                    dicService.AddDicOfDic(dictionary);
                    doneCounter += 1;
                }
                else if (dic.Key == "VehiclesInformation")
                {
                    dicService = new VehicleInformation();
                    dicService.AddDicOfDic(dictionary);
                    doneCounter += 1;
                }
            }
            Console.WriteLine(doneCounter+ "Dictionarys added successfully and " + skippedCounter + " are skipped\n");
        }//done
    }
}

