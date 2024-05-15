using Fleet_Manegment_System.Services.General;
using Npgsql;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_Manegment_System.Services.Geofences
{
    internal class Circular : Geofences
    {
        public ConcurrentDictionary<string, DataTable>? GetAllCircularGeofences()
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetAllCircularGeofences);
            var connection = GetConnection();

            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }
                DataTable resultTable = new("CircleGeofence");
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using var adapter = new NpgsqlDataAdapter(command);
                    adapter.Fill(resultTable);
                }

                var resultDictionary = new ConcurrentDictionary<string, DataTable>();
                resultDictionary.TryAdd("CircleGeofence", resultTable);
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
        }//add to controller

    }
}
