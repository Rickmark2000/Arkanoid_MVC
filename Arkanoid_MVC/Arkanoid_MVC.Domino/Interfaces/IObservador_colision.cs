using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Modelo.Interfaces
{
    public interface IObservador_colision<T>
    {
       EstadoBola estado(T entity, Canvas element,T entity2,Rectangle[] rect);
    }
}
