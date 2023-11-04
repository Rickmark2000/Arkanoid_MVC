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

        public int Idjugador {  get; set; }
        public int puntos { get; set; }
        public int record { get; set; }

        public Puntuacion()
        {

        }

        public override string ToString()
        {
            return $"puntos:{puntos}, record:{record}";
        }
    }
}
