using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Factory
{
    public interface Ifiguras_Factory<Entyti> where Entyti : Figura
    {
        public Entyti crear(int tamano);
        public Entyti crear();

    }
}
