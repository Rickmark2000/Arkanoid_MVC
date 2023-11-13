using Arkanoid_MVC.Controladores.Factory;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Diseño_Figuras
{
    public class DisenoRectangulo : Diseno
    {

        public DisenoRectangulo(Figura figura) : base(figura)
        {
        }

        public override Shape Implementar(ref Canvas element, Color color_fondo, Color color_borde, int grosor_borde)
        {
            Rectangle plataforma = (Rectangle)Figuras_factory.crear_figura(figura.tipoFigura);
            plataforma.Width = figura.ancho;
            plataforma.Height = figura.alto;
            Canvas.SetTop(plataforma, figura.posicionY);
            Canvas.SetLeft(plataforma, figura.posicionX);
            plataforma.Fill = new SolidColorBrush(color_fondo);
            plataforma.Stroke = new SolidColorBrush(color_borde);
            plataforma.StrokeThickness = grosor_borde;
            element.Children.Add(plataforma);
            return plataforma;
        }
    }
}
