using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
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
    public interface IObservador_colision<R,E>
    {
       Enum estado(E entity, Canvas element,R entity2, Ifiguras_management<Rectangle> rect);
    }
}
