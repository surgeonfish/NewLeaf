using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLeaf
{
    public partial class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper(string dbPath)
        {
            SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = dbPath;
            connectionString = builder.ConnectionString;

            if (!File.Exists(dbPath))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Entries (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT NOT NULL, Content TEXT NOT NULL)";
                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void InsertEntry(string date, string content)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Entries (Date, Content) VALUES (@Date, @Content)";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Content", content);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEntry(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Entries WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEntry(int id, string date, string content)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Entries SET Date = @Date, Content = @Content WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Content", content);
                command.ExecuteNonQuery();
            }
        }

        public List<DatabaseEntry> GetAllEntries()
        {
            var entries = new List<DatabaseEntry>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Entries";
                var command = new SQLiteCommand(sql, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entries.Add(new DatabaseEntry
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetString(1),
                            Content = reader.GetString(2)
                        });
                    }
                }
            }
            return entries;
        }
    }
}
