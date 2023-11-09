using ArkanoidProyecto.Controladores;
using ArkanoidProyecto.Controladores.Patron_factory;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Aplicacion
{
    public class DisenoBola : Diseno
    {
        public DisenoBola(Figura figura) : base(figura)
        {
        }

        public override Shape Implementar(ref Canvas element)
        {
            Rectangle bola = (Rectangle)Figuras_factory.crear_figura(TipoFigura.Rectangulo);
            bola.Width = figura.ancho;
            bola.Height = figura.alto;
            Canvas.SetTop(bola, figura.posicionY);
            Canvas.SetLeft(bola, figura.posicionX);
            bola.Fill = new SolidColorBrush(Colors.Yellow);
            element.Children.Add(bola);
            double s = Canvas.GetLeft(element);
            Console.WriteLine(s);


            return null;
        }
    }
}
