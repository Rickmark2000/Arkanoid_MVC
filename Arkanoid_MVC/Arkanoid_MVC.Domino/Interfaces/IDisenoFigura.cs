using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Domino.Interfaces
{
    public interface IDisenoFigura
    {
        Shape Implementar(ref Canvas element);
    }
}
