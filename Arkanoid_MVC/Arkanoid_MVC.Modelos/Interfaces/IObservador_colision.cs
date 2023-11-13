using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Arkanoid_MVC.Modelos.Enum;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IObservador_colision<I,E> where I : Shape
    {
       EColision estado(I figura, Canvas element);

        EColision estado(I figura, E element);
    }
}
