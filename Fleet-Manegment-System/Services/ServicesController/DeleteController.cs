using FPro;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class DeleteController : IRun
    {
        
        public override void  HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            throw new NotImplementedException();
        }

        public override void  HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
        {
            IDicOfDic dicService;
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
                    dicService = new DriverServices();
                    dicService.DeleteDicOfDic(dictionary);
                }
            }
            Console.WriteLine("drivers deleted successfully \n" + skippedCounter + " drivers are skipped\n");

        }
    }
}
