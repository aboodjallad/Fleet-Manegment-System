using Fleet_Manegment_System.Services.Driver;
using Fleet_Manegment_System.Services.General;
using Fleet_Manegment_System.Services.Vehichles;
using Fleet_Manegment_System.Services.Vehicle;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class UpdateController : IRun
    {
        public override bool HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            IDicOfDT dtService;
            int skippedCounter = 0;
            int doneCounter = 0;

            foreach (var dt in dicOfDT)
            {
                DataTable table = dt.Value;
                if (table == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dt.Key.Contains("Driver"))
                {
                    dtService = new DriverServices();
                    dtService.UpdateDicOfDT(table);
                    doneCounter += 1;
                }
                else if (dt.Key == "Vehicles")
                {
                    dtService = new VehicleServices();
                    dtService.UpdateDicOfDT(table);
                    doneCounter += 1;
                }
                else if (dt.Key == "VehicleInformation")
                {
                    dtService = new VehicleInformation();
                    dtService.UpdateDicOfDT(table);
                    doneCounter += 1;
                }
            }
            Console.WriteLine(doneCounter + "Tabels added successfully and " + skippedCounter + " are skipped\n");
            return true;
        }

        public override bool HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
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
                    dicService.UpdateDicOfDic(dictionary);
                    doneCounter += 1;
                }
                if (dic.Key.Contains("Vehicle"))
                {
                    dicService = new VehicleServices();
                    dicService.UpdateDicOfDic(dictionary);
                    doneCounter += 1;
                }

                if (dic.Key.Contains("gool"))
                {
                    dicService = new VehicleInformation();
                    dicService.UpdateDicOfDic(dictionary);
                    doneCounter += 1;
                }
            }
            Console.WriteLine(doneCounter + " Dictionarys updated successfully and " + skippedCounter + "  are skipped\n");
            return true;
        }
    }
}
