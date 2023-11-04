using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public abstract class Figura
    {
        public float tamano { get; set; }
        public float posicionX { get; set; }
        public float posicionY { get; set; }
        public float direccionX { get; set; }
        public float direccionY { get; set; }
        public TipoFigura tipoFigura { get; set; }

        public Figura(float tamano)
        {
            this.tamano = tamano;
        }

        public Figura()
        {

        }
    }
}
