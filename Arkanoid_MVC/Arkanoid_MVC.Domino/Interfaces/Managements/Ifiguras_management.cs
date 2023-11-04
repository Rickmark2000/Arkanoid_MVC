using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ifiguras_management
    {
        void destruir();
        void mostrar(bool mostrar);
        void posicionar(float posX, float posY);

        void mostrar_datos();
    }
}
