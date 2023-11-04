using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Clases_Atómicas
{
    public class Datos_bancarios
    {
        public int id {  get; set; }
        public int IdUsuario {  get; set; }
        public DateTime f_caducidad {  get; set; }
        public string numero_tarjeta {  get; set; }
    }
}
