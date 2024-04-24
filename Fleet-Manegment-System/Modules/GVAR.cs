using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Modules
{
    internal class GVAR
    {
       


        public Dictionary<string, Dictionary<string, string>> DicOfDic { get; set; }
        public Dictionary<string, DataTable> DicOfDT { get; set; }

        public GVAR()
        {
            DicOfDic = new Dictionary<string, Dictionary<string, string>>();
            DicOfDT = new Dictionary<string, DataTable>();
        }

        // Method to add data to DicOfDic
        public void AddToDicOfDic(string key, Dictionary<string, string> value)
        {
            if (DicOfDic.ContainsKey(key))
            {
                foreach (var item in value)
                {
                    DicOfDic[key][item.Key] = item.Value;
                }
            }
            else
            {
                DicOfDic.Add(key, value);
            }
        }

        // Method to add data to DicOfDT
        public void AddToDicOfDT(string key, DataTable value)
        {
            DicOfDT[key] = value;
        }

        // Example utility to create a DataTable
        public static DataTable CreateDataTableSample()
        {
            DataTable table = new DataTable("Sample");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));

            // Adding some rows to the DataTable
            table.Rows.Add(1, "Vehicle123", "SUV");
            table.Rows.Add(2, "Vehicle456", "Truck");

            return table;
        }
    }

}

