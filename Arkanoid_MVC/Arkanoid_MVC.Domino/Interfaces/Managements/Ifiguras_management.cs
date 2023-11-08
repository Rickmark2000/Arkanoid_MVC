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
        void destruir();
        void anadir(T objeto);
        void mostrar(bool mostrar);
        void posicionar(float posX, float posY);

        void mostrar_datos();
    }
}
