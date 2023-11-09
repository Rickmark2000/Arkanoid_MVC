using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Domino.Modelos
{
    public class Figura_SinVelocidad:Figura
    {
        public Figura_SinVelocidad(TipoFigura tipo) : base(tipo)
        {
        }

        public int numGolpes {  get; set; }
    }
}
