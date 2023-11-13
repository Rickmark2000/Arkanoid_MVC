using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class Rectangle_factory : Figuras_factory
    {

        public override Shape crear()
        {
            return new Rectangle();
        }
    }
}
