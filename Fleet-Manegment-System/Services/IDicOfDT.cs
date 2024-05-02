using FPro;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services
{
    internal interface IDicOfDT
    {
        void AddDicOfDT(DataTable table);
        void DeleteDicOfDT(DataTable table);
        DataTable? GetDicOfDT(DataTable table,string key);
        void UpdateDicOfDT();
    }
}
