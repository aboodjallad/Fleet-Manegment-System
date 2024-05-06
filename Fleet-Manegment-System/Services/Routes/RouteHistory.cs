using Fleet_Manegment_System.Services.General;
using Npgsql;
using System.Collections.Concurrent;
using System.Data;
using System.Numerics;


namespace Fleet_Manegment_System.Services.Routes
{
    internal class RouteHistory
    {
        protected static NpgsqlConnection? GetConnection()
        {
            return DatabaseConnection.Instance.Connection;
        }

        public bool AddRouteHistory(ConcurrentDictionary<string, string> dictionary)
        {
            string sql = @"
        INSERT INTO RouteHistory (vehicleid, vehicledirection, status, vehiclespeed, recordtime, address, latitude, longitude)
        VALUES (@VehicleID, @VehicleDirection, @Status, @VehicleSpeed, @RecordTime, @Address, @Latitude, @Longitude);";
            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                using var command = new NpgsqlCommand(sql, connection);
                _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                _ = BigInteger.TryParse(dictionary["vehicledirection"].ToString(), out BigInteger vehicledirection);
                _ = BigInteger.TryParse(dictionary["latitude"].ToString(), out BigInteger latitude);
                _ = BigInteger.TryParse(dictionary["longitude"].ToString(), out BigInteger longitude);

                command.Parameters.AddWithValue("@VehicleID", vehicleid);
                command.Parameters.AddWithValue("@VehicleDirection", vehicledirection);
                command.Parameters.AddWithValue("@Status", dictionary["status"]);
                command.Parameters.AddWithValue("@VehicleSpeed", dictionary["vehiclespeed"]);
                command.Parameters.AddWithValue("@RecordTime", dictionary["recordtime"]);
                command.Parameters.AddWithValue("@Address", dictionary["address"]);
                command.Parameters.AddWithValue("@Latitude", latitude);
                command.Parameters.AddWithValue("@Longitude", longitude);
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
        } // done

        public ConcurrentDictionary<string, DataTable> GetRouteHistory(ConcurrentDictionary<string, string> dictinoary)
        {
            string sql = @"
            SELECT
                V.VehicleID,
                V.VehicleNumber,
                RH.Address,
                RH.Status,
                RH.Latitude || ',' || RH.Longitude AS Position,
                RH.VehicleDirection,
                RH.VehicleSpeed AS GPSSpeed,
                RH.RecordTime AS GPSTime
            FROM Vehicles V
            JOIN RouteHistory RH ON V.VehicleID = RH.VehicleID
            WHERE V.VehicleID = @VehicleID
            AND CAST(RH.RecordTime AS BIGINT) >= @StartTime
            AND CAST(RH.RecordTime AS BIGINT) <= @EndTime
            ORDER BY RH.RecordTime;";

            var resultTable = new DataTable("RouteHistory");
            using (var connection = GetConnection())
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    _ = BigInteger.TryParse(dictinoary["vehicleid"].ToString(), out BigInteger vehicleid);
                    _ = BigInteger.TryParse(dictinoary["starttime"].ToString(), out BigInteger starttime);
                    _ = BigInteger.TryParse(dictinoary["endtime"].ToString(), out BigInteger endtime);
                    command.Parameters.AddWithValue("@VehicleID", vehicleid);
                    command.Parameters.AddWithValue("@StartTime", starttime);
                    command.Parameters.AddWithValue("@EndTime", endtime);
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(resultTable);
                }

                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Close();
                }
            }

            var resultDictionary = new ConcurrentDictionary<string, DataTable>();
            resultDictionary.TryAdd("RouteHistory", resultTable);
            return resultDictionary;
        }// done
    }
}
