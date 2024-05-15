using FPro;
using System.Collections.Concurrent;
using System.Data;


namespace Fleet_Manegment_System.Services.ServicesController
{
    internal abstract class IRun
    {
        public bool Run(GVAR gvar)
        {
            if (gvar.DicOfDic != null && !gvar.DicOfDic.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDic");
                return(HandleDicOfDic(gvar.DicOfDic));
            }
            else if (gvar.DicOfDT != null && !gvar.DicOfDT.IsEmpty)
            {
                Console.WriteLine("Handling as DicOfDT");
                return(HandleDicOfDT(gvar.DicOfDT));
            }
            else
            {
                
                Console.WriteLine("GVAR is empty or not properly initialized.");
                return false;            
            }
        }
        public abstract bool HandleDicOfDT(ConcurrentDictionary<string, DataTable> dicOfDT);
        public abstract bool HandleDicOfDic(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dicOfDic);



    }
}
