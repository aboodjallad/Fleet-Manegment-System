using FPro;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services.ServicesController
{
    internal class AddController : IRun
    {
        
        public override void HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT)
        {
            IDicOfDT dtService;

            foreach (var dt in dicOfDT)
            {
                if (dt.Key == "Drivers")
                {
                    var table = dt.Value;
                    dtService = new DriverServices();
                    dtService.AddDicOfDT(table);
                }
                else if (dt.Key == "Vehicles")
                {
                    // Assuming a method to handle vehicle data
                }
            }
        }//done

        public override void HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic)
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
                    dicService.AddDicOfDic(dictionary);
                }
                
            }
            Console.WriteLine("drivers added successfully \n" + skippedCounter + " drivers are skipped\n");
        }//done
    }
}

