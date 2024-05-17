using Fleet_Manegment_System.Services.General;
using FPro;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Npgsql;
using System.Collections.Concurrent;
using System.Data;
using System.Net.WebSockets;
using System.Numerics;
using System.Text;


namespace Fleet_Manegment_System.Services.Routes
{
    internal class RouteHistory : IRouteHistoryService
    {
        private readonly IHubContext<VehicleHub> _hubContext;
        public RouteHistory(IHubContext<VehicleHub> hubContext)
        {
            _hubContext = hubContext;
        }
        protected static NpgsqlConnection? GetConnection()
        {
            return DatabaseConnection.Instance.Connection;
        }

        public bool AddRouteHistory(ConcurrentDictionary<string, string> dictionary)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.AddRouteHistory);

            var connection = GetConnection();
            try
            {
                if (connection?.State != ConnectionState.Open)
                {
                    connection?.Open();
                }

                using var command = new NpgsqlCommand(sql, connection);
                _ = BigInteger.TryParse(dictionary["vehicleid"], out BigInteger vehicleid);
                _ = BigInteger.TryParse(dictionary["vehicledirection"], out BigInteger vehicledirection);
                _ = BigInteger.TryParse(dictionary["latitude"], out BigInteger latitude);
                _ = BigInteger.TryParse(dictionary["longitude"], out BigInteger longitude);

                command.Parameters.AddWithValue("@VehicleID", vehicleid);
                command.Parameters.AddWithValue("@VehicleDirection", vehicledirection);
                command.Parameters.AddWithValue("@Status", dictionary["status"]);
                command.Parameters.AddWithValue("@VehicleSpeed", dictionary["vehiclespeed"]);
                command.Parameters.AddWithValue("@RecordTime", dictionary["recordtime"]);
                command.Parameters.AddWithValue("@Address", dictionary["address"]);
                command.Parameters.AddWithValue("@Latitude", latitude);
                command.Parameters.AddWithValue("@Longitude", longitude);
                command.ExecuteNonQuery();
                _hubContext.Clients.All.SendAsync("ReceiveRouteHistoryUpdate", dictionary);
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
        public GVAR GetRouteHistory(GVAR gvar)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetRouteHistory);


            DataTable resultTable = new();
            GVAR resultDictionary = new();
            using (var connection = GetConnection())
            {
                try
                {
                    if (connection?.State != ConnectionState.Open)
                    {
                        connection?.Open();
                    }
                    foreach (var dic in gvar.DicOfDic)
                    {
                        var dictinoary = dic.Value;
                        if (dictinoary != null)
                        {
                            using var command = new NpgsqlCommand(sql, connection);
                            _ = BigInteger.TryParse(dictinoary["vehicleid"].ToString(), out BigInteger vehicleid);
                            _ = BigInteger.TryParse(dictinoary["starttime"].ToString(), out BigInteger starttime);
                            _ = BigInteger.TryParse(dictinoary["endtime"].ToString(), out BigInteger endtime);
                            command.Parameters.AddWithValue("@VehicleID", vehicleid);
                            command.Parameters.AddWithValue("@StartTime", starttime);
                            command.Parameters.AddWithValue("@EndTime", endtime);
                            using var adapter = new NpgsqlDataAdapter(command);
                            adapter.Fill(resultTable);
                            resultDictionary.DicOfDT.TryAdd("RouteHistory", resultTable);
                        }
                    }

                    if (connection?.State != ConnectionState.Open)
                    {
                        connection?.Close();
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
            }
            return resultDictionary;
        }// done

        public GVAR GetLastRouteHistory(GVAR gvar)
        {
            var sql = SqlManager.GetSqlCommand(SqlManager.SqlCommands.GetLastRouteHistory);

            DataTable resultTable = new();
            GVAR resultDictionary = new();
            var result = new ConcurrentDictionary<string, string>()
            {
                ["longitude"] = "",
                ["latitude"] = ""
            };

            using (var connection = GetConnection())
            {
                try
                {
                    if (connection?.State != ConnectionState.Open)
                    {
                        connection?.Open();
                    }

                    foreach (var dic in gvar.DicOfDic)
                    {
                        var dictionary = dic.Value;
                        if (dictionary != null)
                        {
                            Console.WriteLine(dictionary["vehicleid"].ToString());
                            Console.WriteLine(dictionary["starttime"].ToString());
                            Console.WriteLine(dictionary["endtime"].ToString());

                            using var command = new NpgsqlCommand(sql, connection);
                            _ = BigInteger.TryParse(dictionary["vehicleid"].ToString(), out BigInteger vehicleid);
                            _ = BigInteger.TryParse(dictionary["starttime"].ToString(), out BigInteger starttime);
                            _ = BigInteger.TryParse(dictionary["endtime"].ToString(), out BigInteger endtime);
                            command.Parameters.AddWithValue("@VehicleID", vehicleid);
                            command.Parameters.AddWithValue("@StartTime", starttime);
                            command.Parameters.AddWithValue("@EndTime", endtime);
                            command.ExecuteNonQuery();
                            using var adapter = new NpgsqlDataAdapter(command);
                            adapter.Fill(resultTable);
                            foreach (DataRow row in resultTable.Rows)
                            {
                                foreach (DataColumn column in resultTable.Columns)
                                {
                                    Console.Write($"{column.ColumnName}: {row[column]} ");
                                }
                                Console.WriteLine();
                            }
                            if (resultTable.Rows.Count > 0)
                            {
                                var longitude = resultTable.Rows[0]["longitude"].ToString();
                                var latitude = resultTable.Rows[0]["latitude"].ToString();

                                if (!string.IsNullOrEmpty(longitude) && !string.IsNullOrEmpty(latitude))
                                {
                                    result["longitude"] = longitude;
                                    result["latitude"] = latitude;
                                }

                                resultDictionary.DicOfDic.TryAdd("route", result);
                            }
                        }
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
            }
            return resultDictionary;
        }
    }
}
