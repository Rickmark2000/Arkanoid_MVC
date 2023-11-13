using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public class Figura_SinVelocidad:Figura
    {
        public Figura_SinVelocidad(TipoFigura tipo) : base(tipo)
        {
        }

        public int numGolpes {  get; set; }
    }
}
