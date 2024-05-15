using Fleet_Manegment_System.Services.General;
using System.Collections.Concurrent;
using System.Data;
using Npgsql;
using System.Numerics;
using FPro;

namespace Fleet_Manegment_System.Services.Vehicle
{
    public class VehicleServices : IDicOfDic, IDicOfDT
    {
        private static NpgsqlConnection? GetConnection()
        {
            return DatabaseConnection.Instance.Connection;
        }

        public void AddDicOfDT(DataTable table)
        {
            var sql =  SqlManager.GetSqlCommand(SqlManager.SqlCommands.InsertVehicle);
            var connection = GetConnection();
            try
            {

                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["vehiclenumber"].ToString(), out BigInteger vehiclenumber);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleNumber", vehiclenumber);
                    command.Parameters.AddWithValue("@vehicleType", row["vehicletype"]);
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
        }//done

        public bool AddDicOfDic(ConcurrentDictionary<string, string> dictionary)//done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.InsertVehicle);
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["vehiclenumber"].ToString(), out BigInteger vehiclenumber);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vehicleNumber", vehiclenumber);
                command.Parameters.AddWithValue("@vehicleType", dictionary["vehicletype"]);
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

        public bool DeleteDicOfDic(ConcurrentDictionary<string, string> dictionary)//done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.DeleteVehicle);
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
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

        public void DeleteDicOfDT(DataTable table)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.DeleteVehicle);
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                foreach (DataRow row in table.Rows)
                {
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleId", (BigInteger)row["vehicleid"]);
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
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetVehicle);
            DataTable resultTable = new(key);
            var connection = GetConnection();
            try
            {
                resultTable.Columns.Add("vehicleid", typeof(BigInteger));
                resultTable.Columns.Add("vehiclenumber", typeof(BigInteger));
                resultTable.Columns.Add("vehicletype", typeof(string));
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    DataTable dt = new();
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleId", (BigInteger)row["vehicleid"]);
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

        public ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string, string> dictionary)//done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetVehicle);
            var connection = GetConnection();
            var result = new ConcurrentDictionary<string, string>()
            {
                ["vehiclenumber"] = "",
                ["vehicletype"] = ""
            };

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                using var command = new NpgsqlCommand(sql, connection);
                DataTable dt = new();
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
                command.ExecuteNonQuery();
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
                var vehiclenumber = dt.Rows[0]["vehiclenumber"].ToString();
                var vehicletype = dt.Rows[0]["vehicletype"].ToString();
                if (vehiclenumber != null && vehicletype != null)
                {
                    result["vehiclenumber"] = vehiclenumber;
                    result["vehicletype"] = vehicletype;
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
        }

        public bool UpdateDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.UpdateVehicle);
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["vehiclenumber"].ToString(), out BigInteger vehiclenumber);
                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
                command.Parameters.AddWithValue("@vehicleNumber", vehiclenumber);
                command.Parameters.AddWithValue("@vehicleType", dictionary["vehicletype"]);
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

        public void UpdateDicOfDT(DataTable table)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.UpdateVehicle);
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["vehiclenumber"].ToString(), out BigInteger vehiclenumber);
                    _ = BigInteger.TryParse(row["vehicleid"].ToString(), out BigInteger vehicleid);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleNumber", vehiclenumber);
                    command.Parameters.AddWithValue("@vehicleType", row["vehicletype"]);
                    command.Parameters.AddWithValue("@vehicleId", vehicleid);
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


        public GVAR? GetVehicle(GVAR gvar)//done
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetVehicle);
            var connection = GetConnection();
            GVAR resultGvar = new();
            var result = new ConcurrentDictionary<string, string>()
            {
                ["vehiclenumber"] = "",
                ["vehicletype"] = ""
            };

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                var dictionary = gvar.DicOfDic["vehicle"];
                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                using var command = new NpgsqlCommand(sql, connection);
                DataTable dt = new();
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
                command.ExecuteNonQuery();
                using (var adapter = new NpgsqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
                var vehiclenumber = dt.Rows[0]["vehiclenumber"].ToString();
                var vehicletype = dt.Rows[0]["vehicletype"].ToString();
                if (vehiclenumber != null && vehicletype != null)
                {
                    result["vehiclenumber"] = vehiclenumber;
                    result["vehicletype"] = vehicletype;
                }
                resultGvar.DicOfDic.TryAdd("vehicle", result);
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
        }

        public GVAR? GetVehicles()//done
        {
            var gvar = new GVAR();
            var sql = "SELECT * FROM vehicles";
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
                    gvar.DicOfDT.TryAdd("Vehicles", dt);
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
    }
}

