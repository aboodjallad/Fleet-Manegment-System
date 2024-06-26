﻿using Fleet_Manegment_System.Services.General;
using Npgsql;
using System.Collections.Concurrent;
using System.Data;
using System.Numerics;
using FPro;
using System.Collections.Generic;

namespace Fleet_Manegment_System.Services.Driver
{
    public class DriverServices : IDicOfDic, IDicOfDT
    {

        public bool AddDicOfDic(ConcurrentDictionary<string, string> dictionary)//done
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.insertDriver);
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                _ = BigInteger.TryParse(dictionary["phonenumber"].ToString(), out BigInteger phonenumber);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@drivername", dictionary["drivername"]);
                command.Parameters.AddWithValue("@phonenumber", phonenumber);
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void AddDicOfDT(DataTable table) //done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.insertDriver);
            var connection = DatabaseConnection.Instance.Connection;
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["phonenumber"].ToString(), out BigInteger phonenumber);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@drivername", row["drivername"]);
                    command.Parameters.AddWithValue("@phonenumber", phonenumber);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred processing the DataTable: {ex.Message}");
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public bool DeleteDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.DeleteDriver);
            var connection = DatabaseConnection.Instance.Connection;
            _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@driverid", driverid);
                command.ExecuteNonQuery();
                Console.WriteLine("driver with ID: " + driverid + " deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public void DeleteDicOfDT(DataTable table)
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.DeleteDriver);


            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["driverid"].ToString(), out BigInteger driverid);
                    using var command = new NpgsqlCommand(sql);
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
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public DataTable? GetDicOfDT(DataTable table, string key)//done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetDriver);
            var connection = DatabaseConnection.Instance.Connection;

            if(connection?.State != ConnectionState.Open)
            {
                connection?.Open();
            }

            try
            {
                DataTable resultTable = new(key);
                resultTable.Columns.Add("driverid", typeof(string));
                resultTable.Columns.Add("drivername", typeof(string));
                resultTable.Columns.Add("phonenumber", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["driverid"].ToString(), out BigInteger driverid);
                    using var command = new NpgsqlCommand(sql, connection);
                    DataTable dt = new();
                    command.Parameters.AddWithValue("@driverid",driverid);
                    command.ExecuteNonQuery();
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(dt);
                    resultTable.ImportRow(dt.Rows[0]);

                }
                return resultTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetDriver);
            var connection = DatabaseConnection.Instance.Connection;

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                DataTable dt = new();
                var result = new ConcurrentDictionary<string, string>()
                {
                    ["drivername"] = "",
                    ["phonenumber"] = ""
                };

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@driverid", driverid);
                    command.ExecuteNonQuery();
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    var drivername = dt.Rows[0]["drivername"].ToString();
                    var phonenumber = dt.Rows[0]["phonenumber"].ToString();
                    if (drivername != null && phonenumber != null)
                    {
                        result["drivername"] = drivername;
                        result["phonenumber"] = phonenumber;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public void UpdateDicOfDT(DataTable table)
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.UpdateDriver);
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                
                foreach (DataRow row in table.Rows)
                {


                    
                    _ = BigInteger.TryParse(row["driverid"].ToString(), out BigInteger driverid);
                    _ = BigInteger.TryParse(row["phonenumber"].ToString(), out BigInteger phonenumber);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@drivername", row["drivername"]);
                    command.Parameters.AddWithValue("@phonenumber", phonenumber);
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
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public bool UpdateDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var connection = DatabaseConnection.Instance.Connection;
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.UpdateDriver);
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                _ = BigInteger.TryParse(dictionary["phonenumber"].ToString(), out BigInteger phonenumber);


                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@drivername", dictionary["drivername"]);
                command.Parameters.AddWithValue("@phonenumber", phonenumber);
                command.Parameters.AddWithValue("@driverid", driverid);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

        public GVAR? GetDrivers()//done
        {
            var gvar = new GVAR();
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetAllDrivers);
            DataTable dt = new();
            var connection = DatabaseConnection.Instance.Connection;

            if (connection?.State != ConnectionState.Open)
            {
                connection?.Open();
            }

            try
            {
                using var command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();
                using var adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvar.DicOfDT.TryAdd("Drivers", dt);
                }
                return gvar;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public GVAR? GetDriver(GVAR gvar)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetDriver);
            GVAR resultGvar = new();
            var connection = DatabaseConnection.Instance.Connection;

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                var dictionary = gvar.DicOfDic["driver"];
                _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                DataTable dt = new();
                var result = new ConcurrentDictionary<string, string>()
                {
                    ["drivername"] = "",
                    ["phonenumber"] = ""
                };

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@driverid", driverid);
                    command.ExecuteNonQuery();
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                    var drivername = dt.Rows[0]["drivername"].ToString();
                    var phonenumber = dt.Rows[0]["phonenumber"].ToString();
                    if (drivername != null && phonenumber != null)
                    {
                        result["drivername"] = drivername;
                        result["phonenumber"] = phonenumber;
                    }
                }
                resultGvar.DicOfDic.TryAdd("driver",result);
                return resultGvar;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }//done

    }


}

