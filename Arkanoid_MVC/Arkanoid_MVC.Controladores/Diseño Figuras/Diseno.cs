
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arkanoid_MVC.Modelos.Interfaces;
using System.Windows.Documents;
using Arkanoid_MVC.Modelos.Modelos;

namespace Arkanoid_MVC.Controladores.Diseño_Figuras
{
    public abstract class Diseno:IDisenoFigura
    {
        protected Figura figura;

        public Diseno(Figura figura)
        {
            this.figura = figura;
        }

        public abstract Shape Implementar(ref Canvas element,Color color_fondo,Color color_borde,int grosor_borde);
    }

}
