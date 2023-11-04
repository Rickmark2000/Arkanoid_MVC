using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ibloques_management : Ifiguras_management, Ilista_figura<Bloque>
    {
        void anadir_valores(int numGolpes,int tamano);
        void destruir(int id);
    }
}
