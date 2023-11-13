using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Arkanoid_MVC.Modelos.Interfaces;

namespace Arkanoid_MVC.Controladores.Factory
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
                case TipoFigura.Elipse:
                    figura = new Elipse_factory().crear();
                    break;

            }
            
            return figura;
        }
        public abstract Shape crear();

    }
}
