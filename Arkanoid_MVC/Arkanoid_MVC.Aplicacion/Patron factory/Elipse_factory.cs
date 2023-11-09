using System;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public class Elipse_factory:Figuras_factory
    {

        public override Shape crear()
        {
            return new Ellipse();
        }
    }
}