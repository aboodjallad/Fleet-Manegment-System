using FPro;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleet_Manegment_System.Services
{
    internal class Driver : IService
    {
        
        public void Add(GVAR gvar)
        {
            if (gvar.DicOfDic.ContainsKey("DriverInfo"))
            {
                var connection = DatabaseConnection.Instance.Connection;
                var driverinfo = gvar.DicOfDic["DriverInfo"];
                var sql = "INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)";
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", driverinfo["drivername"]);
                        command.Parameters.AddWithValue("@number", driverinfo["phonenumber"]);

                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    Console.WriteLine("Unable to execute insert; database connection is not available.");
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
