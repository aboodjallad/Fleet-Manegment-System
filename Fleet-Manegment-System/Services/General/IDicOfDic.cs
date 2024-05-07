using System;
using FPro;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Fleet_Manegment_System.Services.General
{
    internal interface IDicOfDic
    {
        bool AddDicOfDic(ConcurrentDictionary<string, string> dictionary);
        bool DeleteDicOfDic(ConcurrentDictionary<string, string> dictionary);
        ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string, string> dictionary);
        bool UpdateDicOfDic(ConcurrentDictionary<string, string> dictionary);
    }
}
