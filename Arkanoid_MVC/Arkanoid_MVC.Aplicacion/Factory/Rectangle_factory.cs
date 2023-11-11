using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Factory;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public class Rectangle_factory : Figuras_factory
    {

        public override Shape crear()
        {
            return new Rectangle();
        }
    }
}
