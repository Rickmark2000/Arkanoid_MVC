using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public class Figura_Velocidad : Figura
    {
        public Figura_Velocidad(TipoFigura tipo) : base(tipo)
        {
        }

        public int velocidad { get; set; }



    }
}
