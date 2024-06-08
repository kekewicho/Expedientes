using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedientes.Model
{
    internal class Paciente
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public int Estatura { get; set; }
        public string Sexo { get; set; }
        public string ActividadFisica { get; set; }

    }
}
