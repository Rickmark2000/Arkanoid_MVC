using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public class Bolas_Factory : Figuras_factory
    {

        public override Figura crear(int tamano)
        {
            return new Bola(tamano);
        }

        public override Figura crear()
        {
            return new Bola();
        }
    }
}
