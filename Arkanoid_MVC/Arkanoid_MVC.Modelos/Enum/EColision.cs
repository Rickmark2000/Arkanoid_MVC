using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Enum
{
    public enum EColision { EnPlataforma, fuera, choqueBloque, pared,techo ,nada,
        ColisionVertical,
        ColisionHorizontal,
        Izquierda,
        Derecha
    }
}
