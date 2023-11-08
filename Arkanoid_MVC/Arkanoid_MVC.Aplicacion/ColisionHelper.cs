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
        public void ColisionBola(TipoEstado tipo,ref double posX,ref double posY)
        {
            switch (tipo)
            {
                case TipoEstado.EnPlataforma:
                    posY *= -1;
                    break;
                case TipoEstado.pared:
                    posX *= -1;
                    break;
                case TipoEstado.choqueBloque:
                    posY *= -1;
                    break;
                case TipoEstado.techo:
                    posY *= -1;
                    break;
            }
        }

    }
}
