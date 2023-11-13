using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Colisiones
{
    public class ColisionInterseccion
    {
        public void Colision_interseccionY(Ellipse bola, Rectangle bloque,ref double posY)
        {
            bool arriba = (Canvas.GetTop(bola) + bola.Height) >= (Canvas.GetTop(bloque));
            bool abajo = (Canvas.GetTop(bola) >= (Canvas.GetTop(bloque) +bloque.Height));


            if (arriba)
            {
                if (posY > 0)
                {
                    posY *= -1;
                }

            }
            if (abajo)
            {
                posY *=-1;
            }
            

          
        }

        public void Colision_interseccionX(Ellipse bola, Rectangle bloque, ref double posX)
        {
            bool MitadDerecha = (Canvas.GetLeft(bola) + bola.Width) > (Canvas.GetLeft(bloque) + (bloque.Width / 2));
            bool MitadIzquierda = (Canvas.GetLeft(bola) + bola.Width) < (Canvas.GetLeft(bloque) + (bloque.Width / 2));
            bool izquierda = Canvas.GetLeft(bola) + bola.Width <= (Canvas.GetLeft(bloque));
            bool derecha = Canvas.GetLeft(bola) >= (Canvas.GetLeft(bloque) + bloque.Width);

            if (MitadDerecha||derecha)
            {
                posX = Math.Abs(posX);
            }else if (MitadIzquierda||izquierda)
            {
                if (posX > 0)
                {
                    posX *= -1;
                }
               
            }


        }
    }
}
