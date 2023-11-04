using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Clases_Atómicas
{
    public class Password
    {
        public int id { get; set; }
        public int IdUsuario { get; set; }
        public string pass { get; set; }
    }
}
