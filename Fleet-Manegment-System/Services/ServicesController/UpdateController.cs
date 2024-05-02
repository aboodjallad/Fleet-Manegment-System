using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleet_Manegment_System.Services;
namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class UpdateController : IRun
    {
        public override void HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            IDicOfDT dicService;
            int skippedCounter = 0;
            foreach (var dic in dicOfDT)
            {
                DataTable table = dic.Value;
                if (table == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dic.Key == "Driver")
                {
                    dicService = new DriverServices();
                    dicService.UpdateDicOfDT(table);
                }
            }
            Console.WriteLine("drivers updated successfully \n" + skippedCounter + " drivers are skipped\n");
        }

        public override void HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
        {
            IDicOfDic dicService;
            int skippedCounter = 0;
            foreach (var dic in dicOfDic)
            {
                ConcurrentDictionary<string,string> dictionary = dic.Value;
                if (dictionary == null)
                {
                    Console.WriteLine("Dictionary cant be empty \n Skipped");
                    skippedCounter += 1;
                    continue;
                }
                if (dic.Key == "Driver")
                {
                    dicService = new DriverServices();
                    dicService.UpdateDicOfDic(dictionary);
                }
            }
            Console.WriteLine("drivers updated successfully \n" + skippedCounter + " drivers are skipped\n");

        }
    }
}
