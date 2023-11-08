using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ifiguras_management<T> 
    {
       
        void anadir(T objeto);

        T buscar(int value);

        void eliminar(T objeto);

    }
}
