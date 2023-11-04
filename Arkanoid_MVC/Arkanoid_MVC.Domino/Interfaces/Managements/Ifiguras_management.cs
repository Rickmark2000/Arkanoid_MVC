using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Managements
{
    public interface Ifiguras_management
    {
        public void destruir();
        public void mostrar(bool mostrar);
        public void posicionar(float posX, float posY);

        public void mostrar_datos();
    }
}
