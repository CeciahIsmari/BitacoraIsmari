using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Profesor
    {
        public short id_Profe { get; set; }
        public int RegistroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        public string Genero { get; set; }
        public string Categria { get; set; }
        public string Correo { get; set; }
        public string Cel { get; set; }
        public byte fEstadoCivil { get; set; }

    }
}
