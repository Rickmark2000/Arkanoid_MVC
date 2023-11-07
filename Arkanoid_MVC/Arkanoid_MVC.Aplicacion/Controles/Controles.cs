using ArkanoidProyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Controles
{
    public class Controles
    {
        private Plataforma plataforma;
        private Bola bola;
        private bool goLeft, goRight;

        public Controles(Plataforma plataforma, Bola bola)
        {
            this.bola = bola;
            this.plataforma = plataforma;
        }

        public Controles(UIElement element)
        {
            element.AddHandler(UIElement.PreviewKeyUpEvent, new KeyEventHandler(PreviewKeyUpHandler));
            element.AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(PreviewKeyDownHandler));
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

            double limiteIzquierdo = 0, limiteDerecho = 0;
            bool eslimiteDerecho = false, eslimiteIzquierdo = false;
            limiteDerecho = CanvasJuego.ActualWidth - o.Width;
            if (Canvas.GetLeft(o) < limiteIzquierdo)
            {
                eslimiteIzquierdo = true;
            }
            else
            {
                eslimiteIzquierdo = false;
            }

            if (Canvas.GetLeft(o) > limiteDerecho)
            {
                eslimiteDerecho = true;
            }
            else
            {
                eslimiteDerecho = false;
            }


            if (goLeft && !eslimiteIzquierdo)
            {

                posX -= 4;
            }
            if (goRight && !eslimiteDerecho)
            {
                posX += 4;
            }


        }

    }
}
