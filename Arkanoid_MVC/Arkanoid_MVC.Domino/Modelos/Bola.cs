using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public class Bola:Figura_Velocidad
    {

        public float fuerzaLanzado { get; set; }
        public Bola()
        {
            tipoFigura = TipoFigura.Bola;
        }

        public Bola(int tamano):base(tamano)
        {
            tipoFigura = TipoFigura.Bola;
        }

        public override string ToString()
        {
            return $"Es :{tipoFigura}, con una fuerza de:{fuerzaLanzado}";
        }

        
    }
}
