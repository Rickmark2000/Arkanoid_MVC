using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkanoidProyecto.Modelo.Enumeracion;

namespace ArkanoidProyecto.Modelo
{
    public class Plataforma : Figura_Velocidad
    {
        public Plataforma()
        {
            tipoFigura = TipoFigura.Plataforma;
        }

        public Plataforma(int tamano) : base(tamano)
        {
            tipoFigura = TipoFigura.Plataforma;
        }

        public override string ToString()
        {
            return $"Es :{tipoFigura}, con una velocidad de:{velocidad}";
        }
    }
}
