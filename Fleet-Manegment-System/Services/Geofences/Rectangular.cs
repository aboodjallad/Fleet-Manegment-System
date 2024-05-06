using Npgsql;
using System;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Services.Geofences
{
    internal class Rectangular : Geofences
    {
        public ConcurrentDictionary<string,DataTable>? GetAllRectangularGeofences()
        {
            string sql = @"
        SELECT GeofenceID, North, East, West, South
        FROM RectangleGeofence;";
            var connection = GetConnection();

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                DataTable resultTable = new("RectangularGeofences");
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(resultTable);
                }

                var resultDictionary = new ConcurrentDictionary<string, DataTable>();
                resultDictionary.TryAdd("RectangularGeofences", resultTable);
                return resultDictionary;

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
        }// done
    }
}
