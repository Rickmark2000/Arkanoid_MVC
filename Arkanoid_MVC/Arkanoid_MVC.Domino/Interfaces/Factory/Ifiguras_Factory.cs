using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Modelo.Interfaces.Factory
{
    public interface Ifiguras_Factory<Objeto> where Objeto : Shape
    {
        Objeto crear();

    }
}
