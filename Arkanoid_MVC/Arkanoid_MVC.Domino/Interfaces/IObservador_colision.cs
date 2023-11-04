using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces
{
    public interface IObservador_colision<T> where T : class
    {
       string estado(T entity);
    }
}
