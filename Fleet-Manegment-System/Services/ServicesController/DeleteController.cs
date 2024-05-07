using Fleet_Manegment_System.Services.General;
using Fleet_Manegment_System.Services.Driver;
using Fleet_Manegment_System.Services.Vehicle;
using System.Collections.Concurrent;
using System.Data;
using Fleet_Manegment_System.Services.Vehichles;
using System.Linq.Expressions;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class DeleteController : IRun
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
                if (dt.Key == "Driver")
                {
                    dtService = new DriverServices();
                    dtService.DeleteDicOfDT(table);
                    doneCounter += 1;
                }
                if (dt.Key.Contains("Vehicles"))
                {
                    dtService = new VehicleServices();
                    dtService.DeleteDicOfDT(table);
                    doneCounter += 1;
                }
                if (dt.Key.Contains("gool"))
                {
                    dtService = new VehicleInformation();
                    dtService.DeleteDicOfDT(table);
                    doneCounter += 1;
                }
            }
            Console.WriteLine(doneCounter + "Tabels deleted successfully and " + skippedCounter + " are skipped\n");
            return true;
        }

        public override bool  HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
        {
            IDicOfDic dicService;
            int skippedCounter = 0;
            int doneCounter = 0;
            foreach (var dic in dicOfDic)
            {
                var key = dic.Key;
                var dictionary = dic.Value;

                if (dictionary == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }

                if (dic.Key.Contains("Vehicle"))
                {
                    dicService = new VehicleServices();
                    dicService.DeleteDicOfDic(dictionary);
                    doneCounter += 1;
                }

                if (dic.Key.Contains("Driver"))
                {
                    dicService = new DriverServices();
                    dicService.DeleteDicOfDic(dictionary);
                    doneCounter += 1;
                }
                
                if (dic.Key.Contains("gool"))
                {
                    dicService = new VehicleInformation();
                    dicService.DeleteDicOfDic(dictionary);
                    doneCounter += 1;
                }

            }
            Console.WriteLine(doneCounter + " Dictionarys deleted successfully" + skippedCounter + "  are skipped\n");
            return true;
        }
    }
}
