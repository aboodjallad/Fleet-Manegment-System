using Fleet_Manegment_System.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services
{
    internal interface IService
    {
        void Add(GVAR gvar);
        void Delete();
        void Get();
        void Update();
    }
}
