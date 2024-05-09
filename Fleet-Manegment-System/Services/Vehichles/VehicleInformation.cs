using Fleet_Manegment_System.Services.General;
using System.Collections.Concurrent;
using System.Data;
using Npgsql;
using System.Numerics;
using FPro;


namespace Fleet_Manegment_System.Services.Vehichles
{
    internal class VehicleInformation : IDicOfDic,IDicOfDT
    {
        private static NpgsqlConnection? GetConnection()
        {
            return DatabaseConnection.Instance.Connection;
        }
        
        public void AddDicOfDT(DataTable table)
        {
            var sql = @"INSERT INTO VehiclesInformations 
                 (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate)  
                VALUES (@vehicleId, @driverId, vehicleMake, vehicleModel, purchaseDate);";
            var connection = GetConnection();
            try
            {

                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["vehicleid"].ToString(), out BigInteger vehicleid);
                    _ = BigInteger.TryParse(row["driverid"].ToString(), out BigInteger driverid);
                    _ = BigInteger.TryParse(row["purchasedate"].ToString(), out BigInteger purchasedate);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleId", vehicleid);
                    command.Parameters.AddWithValue("@driverId", driverid);
                    command.Parameters.AddWithValue("@vehicleMake", row["vehiclemake"]);
                    command.Parameters.AddWithValue("@vehicleModel", row["vehiclemodel"]);
                    command.Parameters.AddWithValue("@purchaseDate", purchasedate);
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

            var sql = "INSERT INTO VehiclesInformations (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate) VALUES (@vehicleId, @driverId, @vehicleMake, @vehicleModel, @purchaseDate)";
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                _ = BigInteger.TryParse(dictionary["purchasedate"].ToString(), out BigInteger purchasedate);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
                command.Parameters.AddWithValue("@driverId", driverid);
                command.Parameters.AddWithValue("@vehicleMake", dictionary["vehiclemake"]);
                command.Parameters.AddWithValue("@vehicleModel", dictionary["vehiclemodel"]);
                command.Parameters.AddWithValue("@purchaseDate", purchasedate);
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
            var sql = "DELETE FROM VehiclesInformations WHERE vehicleid = @vehicleId";
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
            var sql = "DELETE FROM VehiclesInformations WHERE vehicleid = @vehicleId";
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
            throw new NotImplementedException();
        }

        public ConcurrentDictionary<string, string>? GetDicOfDic(ConcurrentDictionary<string, string> dictionary)//done
        {
            throw new NotImplementedException();

        }

        public bool UpdateDicOfDic(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = "UPDATE VehiclesInformations SET driverid = @driverId, vehiclemake = @vehicleMake, vehiclemodel = @vehicleModel, purchasedate = @purchaseDate WHERE vehicleid = @vehicleId";
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                _ = BigInteger.TryParse(dictionary["purchasedate"].ToString(), out BigInteger purchasedate);
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@vehicleId", vehicleid);
                command.Parameters.AddWithValue("@driverId", driverid);
                command.Parameters.AddWithValue("@vehicleMake", dictionary["vehiclemake"]);
                command.Parameters.AddWithValue("@vehicleModel", dictionary["vehiclemodel"]);
                command.Parameters.AddWithValue("@purchaseDate", purchasedate); ;
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
            var sql = "UPDATE VehiclesInformations" +
                            " SET driverid = @driverId, vehiclemake = @vehicleMake, vehiclemodel = @vehicleModel, purchasedate = @purchaseDate" +
                            " WHERE vehicleid = @vehicleId";
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                foreach (DataRow row in table.Rows)
                {
                    _ = BigInteger.TryParse(row["vehicleid"].ToString(), out BigInteger vehicleid);
                    _ = BigInteger.TryParse(row["driverid"].ToString(), out BigInteger driverid);
                    _ = BigInteger.TryParse(row["purchasedate"].ToString(), out BigInteger purchasedate);
                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@vehicleId", vehicleid);
                    command.Parameters.AddWithValue("@driverId", driverid);
                    command.Parameters.AddWithValue("@vehicleMake", row["vehiclemake"]);
                    command.Parameters.AddWithValue("@vehicleModel", row["vehiclemodel"]);
                    command.Parameters.AddWithValue("@purchaseDate", purchasedate); ;
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

        public void AssignOrUpdateVehicleDriver(ConcurrentDictionary<string, ConcurrentDictionary<string, string>> dictionarys)
        {
            var connection = GetConnection();
            string sql = @"
            UPDATE VehiclesInformations
            SET driverid = @DriverId
            WHERE vehicleid = @VehicleID;";
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                foreach (var dic in dictionarys)
                {
                    var dictionary = dic.Value;
                    _ = BigInteger.TryParse(dictionary["driverid"].ToString(), out BigInteger driverid);
                    _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);

                    using var command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@VehicleID", vehicleid);
                    command.Parameters.AddWithValue("@DriverId", driverid);

                    int result = command.ExecuteNonQuery();
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
        }// done

        public  GVAR? GetVehiclesInformation()
        {
            var sql = "SELECT V.VehicleID, V.VehicleNumber,V.VehicleType, RH.VehicleDirection AS LastDirection, RH.Status AS LastStatus, RH.Address AS LastAddress, RH.Latitude || ',' || RH.Longitude AS LastPosition FROM Vehicles V JOIN RouteHistory RH ON V.VehicleID = RH.VehicleID  ORDER BY RH.RecordTime DESC;";
            DataTable dt = new();
            GVAR gvar = new();
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                using var command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();
                using var adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvar.DicOfDT.TryAdd("VehiclesInformation", dt);
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
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Close();
                }
            }

            
        }// done

        public  GVAR? GetSpecificVehicleInformation(BigInteger vehicleId)
        {
            string sql = @"
            SELECT
                V.VehicleNumber,
                V.VehicleType,
                D.DriverName,
                D.PhoneNumber,
                R.Latitude || ',' || R.Longitude AS LastPosition,
                VI.VehicleMake,
                VI.VehicleModel,
                R.RecordTime AS LastGPSTime,
                R.VehicleSpeed AS LastGPSSpeed,
                R.Address AS LastAddress
            FROM Vehicles V
            JOIN VehiclesInformations VI ON V.VehicleID = VI.VehicleID
            JOIN Driver D ON VI.DriverId = D.DriverID
            LEFT JOIN RouteHistory R ON V.VehicleID = R.VehicleID
            WHERE V.VehicleID = @VehicleID
            ORDER BY R.RecordTime DESC;";

            DataTable resultTable = new();
            using var connection = GetConnection();
            if (connection?.State != ConnectionState.Open)
            {
                connection?.Open();
            }
            try
            {
                using var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@VehicleID", vehicleId);
                command.ExecuteNonQuery();
                using var adapter = new NpgsqlDataAdapter(command);
                adapter.Fill(resultTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Close();
                }
            }
            GVAR resultDictionary = new();
            resultDictionary.DicOfDT.TryAdd("VehicleInformation", resultTable);
            return resultDictionary;
        }// done
    }
}
