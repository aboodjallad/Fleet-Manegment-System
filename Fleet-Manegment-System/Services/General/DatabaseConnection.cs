using Npgsql;

namespace Fleet_Manegment_System.Services.General
{
    internal class DatabaseConnection
    {
        private static volatile DatabaseConnection? _instance;
        private static readonly object _lock = new();
        private NpgsqlConnection? _connection;
        private readonly string _connectionString = "Host=localhost; Port=5432; Database=postgres; Username=postgres; Password=123";

        private DatabaseConnection()
        {
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            try
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Failed to open database connection: {ex.Message}");
                _connection = null;
            }
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnection();
                            Console.WriteLine("Lestning.....");
                        }
                    }
                }
                return _instance;
            }
        }

        public NpgsqlConnection? Connection
        {
            get
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    InitializeConnection();
                }
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
