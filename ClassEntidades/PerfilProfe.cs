using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class PerfilProfe
    {
        public int id_Perfil { get; set; }
        public short F_Profe { get; set; }
        public short F_Grado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaObtencion { get; set; }
        public string Evidencia { get; set; }
    }
}
