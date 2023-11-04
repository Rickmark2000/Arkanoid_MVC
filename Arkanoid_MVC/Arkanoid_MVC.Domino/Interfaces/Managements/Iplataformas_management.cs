using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Iplataformas_management : Ifiguras_management
    {
        public void anadir_valores(int velocidad, float tamano);
    }
}
