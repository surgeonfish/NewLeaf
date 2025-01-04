using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
                string sql = "CREATE TABLE IF NOT EXISTS Leaves (Id INTEGER PRIMARY KEY AUTOINCREMENT, Content TEXT NOT NULL, Color TEXT NOT NULL, DateCreated TEXT NOT NULL, DateLastUpdated TEXT NOT NULL)";
                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public void InsertEntry(string dateCreated, string leafContent, Color leafColor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Leaves (Content, Color, DateCreated, DateLastUpdated) VALUES (@Content, @Color, @DateCreated, @DateLastUpdated)";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Content", leafContent);
                command.Parameters.AddWithValue("@Color", leafColor.ToString());
                command.Parameters.AddWithValue("@DateCreated", dateCreated);
                // The last upated date should be the same as the created data upon creation.
                command.Parameters.AddWithValue("@DateLastUpdated", dateCreated);
                command.ExecuteNonQuery();
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

        public void UpdateEntry(DatabaseEntry databaseEntry)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE Leaves SET Content = @Content, Color = @Color, DateLastUpdated = @DateLastUpdated WHERE Id = @Id";
                var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", databaseEntry.LeafId);
                command.Parameters.AddWithValue("@Content", databaseEntry.LeafContent);
                command.Parameters.AddWithValue("@Color", databaseEntry.LeafColor.ToString());
                command.Parameters.AddWithValue("@DateLastUpdated", databaseEntry.DateLastUpdated);
                command.ExecuteNonQuery();
            }
        }

        public List<DatabaseEntry> GetAllEntries()
        {
            var entries = new List<DatabaseEntry>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Leaves";
                var command = new SQLiteCommand(sql, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entries.Add(new DatabaseEntry
                        {
                            LeafId = reader.GetInt32(0),
                            LeafContent = reader.GetString(1),
                            LeafColor = (Color)ColorConverter.ConvertFromString(reader.GetString(2)),
                            DateCreated = reader.GetString(3),
                            DateLastUpdated = reader.GetString(4),
                        });
                    }
                }
            }
            return entries;
        }
    }
}
