using System;
using System.Data.SQLite;
using System.IO;

namespace NewLeaf.Model
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
                string sql = "CREATE TABLE IF NOT EXISTS Leaves (Id INTEGER PRIMARY KEY AUTOINCREMENT, Content TEXT NOT NULL, Color TEXT NOT NULL, DateCreated TEXT NOT NULL, DateLastUpdated TEXT NOT NULL)";
                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public long InsertEntry(string dateCreated, string leafContent, string leafColor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Leaves (Content, Color, DateCreated, DateLastUpdated) VALUES (@Content, @Color, @DateCreated, @DateLastUpdated); SELECT last_insert_rowid();";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Content", leafContent);
                command.Parameters.AddWithValue("@Color", leafColor);
                command.Parameters.AddWithValue("@DateCreated", dateCreated);
                // The last upated date should be the same as the created data upon creation.
                command.Parameters.AddWithValue("@DateLastUpdated", dateCreated);
                long lastId = (long)command.ExecuteScalar();
                return lastId;
            }
        }

        public void DeleteEntry(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Leaves WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateContent(int id, string content)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Leaves SET Content = @Content, DateLastUpdated = @DateLastUpdated WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Content", content);
                command.Parameters.AddWithValue("@DateLastUpdated", DateTime.Now.ToString("yyyy-MM-dd"));
                command.ExecuteNonQuery();
            }
        }

        public void UpdateColor(int id, string color)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Leaves SET Color = @Color, DateLastUpdated = @DateLastUpdated WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Color", color);
                command.Parameters.AddWithValue("@DateLastUpdated", DateTime.Now.ToString("yyyy-MM-dd"));
                command.ExecuteNonQuery();
            }
        }

        public void GetAllLeaves(Func<LeafModel, int> Adder)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Leaves";
                var command = new SQLiteCommand(sql, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var leaf = new LeafModel()
                        {
                            Id = reader.GetInt32(0),
                            Content = reader.GetString(1),
                            Color = reader.GetString(2),
                            DateCreated = reader.GetString(3),
                            DateLastUpdated = reader.GetString(4),
                            DatabaseHelper = this,
                        };
                        Adder(leaf);
                    }
                }
            }
        }

        public LeafModel GetLeaf(long id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Leaves WHERE id = @id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    var leaf = new LeafModel()
                    {
                        Id = reader.GetInt32(0),
                        Content = reader.GetString(1),
                        Color = reader.GetString(2),
                        DateCreated = reader.GetString(3),
                        DateLastUpdated = reader.GetString(4),
                        DatabaseHelper = this,
                    };
                    return leaf;
                }
            }
        }
    }
}
