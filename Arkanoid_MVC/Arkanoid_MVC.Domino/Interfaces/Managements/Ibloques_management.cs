using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ibloques_management<T> : Ifiguras_management<T>, Ilista_figura<T>
    {
        void anadir_valores(int numGolpes,int tamano);
        void destruir(int id);
        
    }
}
