using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedientes
{
    internal class Database
    {
        private string connectionString;

        public Database(string databasePath)
        {
            connectionString = $"Data Source={databasePath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS Pacientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Edad TEXT NOT NULL,
                    Peso TEXT NOT NULL,
                    Estatura TEXT NOT NULL,
                    Sexo TEXT NOT NULL,
                    ActividadFisica TEXT NOT NULL
                );";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public void AllPacientes()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                
                 string sql = "SELECT * FROM Pacientes";
                 using (var command = new SQLiteCommand(sql, connection))
                 using (var reader = command.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         // Procesar los resultados
                     }
                 }
            }
        }

        public List<(int Id, string Name, byte[] Template)> GetAllFingerprints()
        {
            var fingerprints = new List<(int Id, string Name, byte[] Template)>();
            using (var connection = GetConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Fingerprints";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fingerprints.Add((reader.GetInt32(0), reader.GetString(1), (byte[])reader.GetValue(2)));
                    }
                }
            }
            return fingerprints;
        }
    }
}
