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
    internal abstract class IRun
    {
        public void Run(GVAR gvar)
        {
            if (gvar.DicOfDic != null && !gvar.DicOfDic.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDic");
                HandleDicOfDic(gvar.DicOfDic);
            }
            else if (gvar.DicOfDT != null && !gvar.DicOfDT.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDT");
                HandleDicOfDT(gvar.DicOfDT);
            }
            else
            {
                Console.WriteLine("GVAR is empty or not properly initialized.");
            }
        }
        public abstract void HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT);
        public abstract void HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic);



    }
}
