using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IDisenoFigura
    {
        Shape Implementar(ref Canvas element, Color color_fondo, Color color_borde, int grosor_borde);
    }
}
