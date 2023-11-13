using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public abstract class Figura
    {
        public double ancho { get; set; }
        public double alto { get; set; }
        public double tamano { get; set; }
        public double posicionX { get; set; }
        public double posicionY { get; set; }
        public TipoFigura tipoFigura { get; set; }

        public Figura(TipoFigura tipo)
        {
            this.tipoFigura = tipo;
        }
    }
}
