using Arkanoid_MVC.Domino.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ifiguras_management<T>:IDictionaryFigura<int, T>
    {
       
        void anadir(T objeto);

        T buscar(int value);

        void eliminar(int value);

        List<T> ObtenerList();

    }
}
