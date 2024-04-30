using FPro;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services
{
    public class DriverServices : IService
    {

        public void Add(GVAR gvar)
        {
            if (gvar.DicOfDic.ContainsKey("DriverInfo"))
            {
                InsertDriverInfo(gvar); 
            }
            else if (gvar.DicOfDT.ContainsKey("DriverTable"))
            {
                InsertDriverTable(gvar); 
            }
            else
            {
                Console.WriteLine("Driver information not found in the provided object.");
            }
        }

        static private void InsertDriverInfo(GVAR gvar)
        {
            var driverInfo = gvar.DicOfDic["DriverInfo"];
            var sql = "INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)";
            var connection = DatabaseConnection.Instance.Connection;
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@drivername", driverInfo["drivername"]);
                    command.Parameters.AddWithValue("@phonenumber", driverInfo["phonenumber"]);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (connection?.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        static private void InsertDriverTable(GVAR gvar)
        {
            var driverTable = gvar.DicOfDT["DriverInfo"];
            var connection = DatabaseConnection.Instance.Connection;
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in driverTable.Rows)
                {
                    using (var command = new NpgsqlCommand("INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)", connection))
                    {
                        command.Parameters.AddWithValue("@drivername", row["drivername"]);
                        command.Parameters.AddWithValue("@phonenumber", row["phonenumber"]);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred processing the DataTable: {ex.Message}");
            }
            finally
            {
                if (connection?.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
