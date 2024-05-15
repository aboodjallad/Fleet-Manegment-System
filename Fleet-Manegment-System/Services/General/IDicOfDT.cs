using System.Data;

namespace Fleet_Manegment_System.Services.General
{
    internal interface IDicOfDT
    {
        void AddDicOfDT(DataTable table);
        void DeleteDicOfDT(DataTable table);
        DataTable? GetDicOfDT(DataTable table, string key);
        void UpdateDicOfDT(DataTable table);
    }
}
