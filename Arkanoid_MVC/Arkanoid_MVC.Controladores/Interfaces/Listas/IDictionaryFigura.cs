using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Interfaces
{
    public interface IDictionaryFigura<T,E>
    {
       Dictionary<T,E> lista_figura { get; }
    }
}
