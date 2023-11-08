using ArkanoidProyecto.Controladores.Managements;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces.Factory;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public abstract class Figuras_factory : Ifiguras_Factory<Shape>
    {
        public static Shape crear_figura(TipoFigura tipo)
        {
            Shape figura = null;
            switch (tipo)
            {
                case TipoFigura.Rectangulo:
                    figura = new Rectangle_factory().crear();
                    break;
            }

            return figura;
        }
        public abstract Shape crear();

    }
}
