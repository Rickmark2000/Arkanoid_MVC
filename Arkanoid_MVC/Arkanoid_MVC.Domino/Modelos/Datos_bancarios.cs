using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Clases_Atómicas
{
    public class Datos_bancarios
    {
        public int Id { get; set; }
        public int id_Usuario { get; set; }
        public DateTime f_caducidad { get; set; }
        public string numeroTarjeta { get; set; }

        public string entidad { get; set; }
    }
}
