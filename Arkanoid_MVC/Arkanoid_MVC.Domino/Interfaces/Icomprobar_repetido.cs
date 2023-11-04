using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces
{
    public interface Icomprobar_repetido<Entity>
    {
        bool repetido(Entity entity);
    }
}
