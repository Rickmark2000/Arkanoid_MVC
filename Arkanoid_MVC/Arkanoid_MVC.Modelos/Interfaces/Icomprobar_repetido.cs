using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface Icomprobar_repetido<Entity>
    {
        bool repetido(Entity entity);
    }
}
