using FPro;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Fleet_Manegment_System.Services
{
    public class DriverServices : IDicOfDic , IDicOfDT
    {

        public void AddDicOfDic(ConcurrentDictionary<string,string> dictionary)//done
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = "INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)";
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@drivername", dictionary["drivername"]);
                command.Parameters.AddWithValue("@phonenumber", dictionary["phonenumber"]);
                command.ExecuteNonQuery();

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

        public void AddDicOfDT(DataTable table) //done
        {
            var sql = "INSERT INTO driver (drivername, phonenumber) VALUES (@drivername, @phonenumber)";
            var connection = DatabaseConnection.Instance.Connection;
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@drivername", row["drivername"]);
                    command.Parameters.AddWithValue("@phonenumber", row["phonenumber"]);

                    command.ExecuteNonQuery();
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

        public void DeleteDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = "DELETE FROM driver WHERE driverid = @driverid";
            var connection = DatabaseConnection.Instance.Connection;
            string numberStr = dictionary["driverid"];
            int driverid = int.Parse(numberStr);
            try
            {
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@driverid", driverid);
                connection?.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("driver with ID: " + driverid + " deleted successfully");
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
        }//done

        public void DeleteDicOfDT(DataTable table)
        {
            var connection = DatabaseConnection.Instance.Connection;

            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    string numberStr = (string)row["driverid"];
                    int driverid = int.Parse(numberStr);
                    using var command = new NpgsqlCommand("DELETE FROM driver WHERE driverid = @driverid", connection);
                    command.Parameters.AddWithValue("@driverid", driverid);
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
        }//done

        public DataTable? GetDicOfDT(DataTable table, string key)//done
        {
            var sql = "SELECT * FROM driver WHERE driverid = @driverid";
            var connection = DatabaseConnection.Instance.Connection;
            string tableName = key;
            try
            {
                DataTable resultTable = new(tableName);
                resultTable.Columns.Add("driverid", typeof(BigInteger));
                resultTable.Columns.Add("drivername", typeof(string));
                resultTable.Columns.Add("phonenumber", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    var driverid = (BigInteger)row["driverId"];
                    using var command = new NpgsqlCommand(sql, connection);
                    DataTable dt = new();
                    command.Parameters.AddWithValue("@driverid", driverid);
                    connection?.Open();
                    command.ExecuteNonQuery();
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(dt);
                    resultTable.ImportRow(dt.Rows[0]);

                }
                return resultTable;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string,string> dictionary, string key)
        {
            var sql = "SELECT * FROM driver WHERE driverid = @driverid";
            var connection = DatabaseConnection.Instance.Connection;

            try
            {
                string numberStr = dictionary["driverid"];
                int driverid = int.Parse(numberStr);
                DataTable dt = new();
                var newDictionary = new ConcurrentDictionary<string, string>()
                {
                    ["drivername"] = "",
                    ["phonenumber"] = ""
                };

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@driverid", driverid);
                    connection?.Open();
                    command.ExecuteNonQuery();
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    var drivername = dt.Rows[0]["drivername"].ToString();
                    var phonenumber = dt.Rows[0]["phonenumber"].ToString();
                    newDictionary["drivername"] = drivername;
                    newDictionary["phonenumber"] = phonenumber;
                }
                return newDictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public void UpdateDicOfDT(DataTable table)
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = "UPDATE driver SET drivername = @drivername, phonenumber = @phonenumber WHERE driverid = @driverid";
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }
                foreach (DataRow row in table.Rows)
                {
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@drivername", row["drivername"]);
                    command.Parameters.AddWithValue("@phonenumber", row["phonenumber"]);
                    command.Parameters.AddWithValue("@driverid", row["driverid"]);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception  ex)
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
        }//done

        public void UpdateDicOfDic(ConcurrentDictionary<string,string> dictionary)
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = "UPDATE driver SET drivername = @drivername, phonenumber = @phonenumber WHERE driverid = @driverid";
            try
            {
                if (connection?.State != System.Data.ConnectionState.Open)
                {
                    connection?.Open();
                }
                string numberStr = dictionary["driverid"];
                int driverid = int.Parse(numberStr);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@drivername", dictionary["drivername"]);
                command.Parameters.AddWithValue("@phonenumber", dictionary["phonenumber"]);
                command.Parameters.AddWithValue("@driverid",driverid);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
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
        }//done

    }
}

