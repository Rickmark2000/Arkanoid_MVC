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
    public interface IObservador_colision<I,E> where I : Shape
    {
       EColision estado(I figura, Canvas element);

        EColision estado(I figura, E element);
    }
}
