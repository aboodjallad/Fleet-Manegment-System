using System;
using FPro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Fleet_Manegment_System.Services
{
    internal interface IDicOfDic
    {
        void AddDicOfDic(ConcurrentDictionary<string,string> dictionary);
        void DeleteDicOfDic(ConcurrentDictionary<string, string> dictionary);
        ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string,string> dictionary , string key);
        void UpdateDicOfDic(ConcurrentDictionary<string , string> dictionary);
    }
}
