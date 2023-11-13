using System;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class Elipse_factory:Figuras_factory
    {

        public override Shape crear()
        {
            return new Ellipse();
        }
    }
}