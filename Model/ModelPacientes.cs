using Java.Util.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedientes.Model
{
    internal class ModelPacientes
    {
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public Database db;

        public void AllNotes() =>
            LoadPacientes();

        private void LoadPacientes ()
        {
            Pacientes.Clear();

            db = new Database("database.db");

            using (var connection = db.GetConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM Pacientes";
                using (var command = new SQLiteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pacientes.Add(new Paciente
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                            Edad = reader.GetInt32(reader.GetOrdinal("Edad")),
                            Peso = reader.GetDouble(reader.GetOrdinal("Peso")),
                            Estatura = reader.GetInt32(reader.GetOrdinal("Estatura")),
                            Sexo = reader.GetString(reader.GetOrdinal("Sexo")),
                            ActividadFisica = reader.GetString(reader.GetOrdinal("ActividadFisica"))
                        });
                    }
                }

            }

        }
        


    }
}
