using Fleet_Manegment_System.Services.General;
using Npgsql;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Services.Geofences
{
    internal class Geofences
    {
        protected static NpgsqlConnection? GetConnection()
        {
            return DatabaseConnection.Instance.Connection;
        }

        public ConcurrentDictionary<string, DataTable>? GetAllGeofences()
        {
            string sql = "SELECT * FROM geofences";
            var connection = GetConnection();

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                DataTable resultTable = new("Geofences");
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(resultTable);
                }

                var resultDictionary = new ConcurrentDictionary<string, DataTable>();
                resultDictionary.TryAdd("Geofences", resultTable);
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
