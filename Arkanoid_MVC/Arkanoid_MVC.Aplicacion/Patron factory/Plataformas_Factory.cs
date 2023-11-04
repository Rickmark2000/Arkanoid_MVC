using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Factory;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public class Plataformas_Factory : Ifiguras_Factory<Figura>
    {
        public Figura crear(int tamano)
        {
            return new Plataforma(tamano);
        }

        public Figura crear()
        {
            return new Plataforma();
        }
    }
}
