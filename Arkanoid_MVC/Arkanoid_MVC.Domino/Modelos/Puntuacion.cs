using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public class Puntuacion
    {
        public int id {  get; set; }

        public int idjugador {  get; set; }
        public int puntuacion { get; set; }
        public int puntuacion_record { get; set; }

        public Puntuacion()
        {

        }

        public override string ToString()
        {
            return $"puntos:{puntuacion}, record:{puntuacion_record}";
        }
    }
}
