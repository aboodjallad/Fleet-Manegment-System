using FPro;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services.Routes
{
    public interface IRouteHistoryService
    {
        GVAR GetRouteHistory(GVAR gvar);
        bool AddRouteHistory(ConcurrentDictionary<string, string> dictionary);
    }
}
