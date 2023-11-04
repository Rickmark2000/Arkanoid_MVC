using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ibolas_management : Ifiguras_management
    {
        void anadir_valores(float fuerza,int velocidad,int tamano);
    }
}
