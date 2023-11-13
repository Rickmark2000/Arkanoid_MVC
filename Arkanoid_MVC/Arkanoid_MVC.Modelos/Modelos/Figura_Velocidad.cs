using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public class Figura_Velocidad : Figura
    {
        public Figura_Velocidad(TipoFigura tipo) : base(tipo)
        {
        }

        public int velocidad { get; set; }



    }
}
