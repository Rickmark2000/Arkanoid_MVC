using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Controles
{
    public class Controles_jugador
    {
        private bool goLeft, goRight;
        private float velocidad;

        public Controles_jugador(UIElement element,float velocidad)
        {
            element.AddHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(PreviewKeyUpHandler));
            element.AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(PreviewKeyDownHandler));
            this.velocidad = velocidad;
        }

        private void PreviewKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            else if (e.Key == Key.Right) { goRight = false; }
        }

        private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = true;
            }
            else if (e.Key == Key.Right) { goRight = true; }
        }

        public void mover(Rectangle o, ref double posX, Canvas CanvasJuego)
        {

            double limiteIzquierdo = 0;
            double limiteDerecho = CanvasJuego.ActualWidth - o.Width;
            if (!(Canvas.GetLeft(o) < limiteIzquierdo)&& goLeft)
            {
                posX -= velocidad;
            }

            if (!(Canvas.GetLeft(o) > limiteDerecho) && goRight)
            {
                posX += velocidad;
            }

        }

    }
}
