using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Aplicacion
{
    public class ColisionHelper
    {
        public void ColisionBola(EstadoBola tipo,ref double posX,ref double posY)
        {
            switch (tipo)
            {
                case EstadoBola.EnPlataforma:
                case EstadoBola.techo:
                    posY *= -1;
                    break;
                case EstadoBola.pared:
                    posX *= -1;
                    break;
                case EstadoBola.choqueBloque:
                    posY *= -1;
                    posX *= -1;
                    break;
            }
        }

    }
}
