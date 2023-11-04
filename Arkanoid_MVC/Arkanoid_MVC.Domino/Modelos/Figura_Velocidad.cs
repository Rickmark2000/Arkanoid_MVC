using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public abstract class Figura_Velocidad : Figura
    {
        public int velocidad { get; set; }
        public Figura_Velocidad(float tamano) : base(tamano)
        {
        }

        public Figura_Velocidad()
        {

        }



    }
}
