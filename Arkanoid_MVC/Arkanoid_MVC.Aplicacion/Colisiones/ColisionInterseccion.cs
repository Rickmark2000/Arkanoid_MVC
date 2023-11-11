using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Aplicacion.Colisiones
{
    public class ColisionInterseccion
    {
        public void Colision_interseccion(Ellipse bola, Rectangle bloque, ref double posX, ref double posY)
        {
            if ((Canvas.GetLeft(bola)+bola.Width) < (Canvas.GetLeft(bloque)+(bloque.Width/2)))
            {
                if (posX > 0)
                {
                    posX *= -1;
                }
            }
            else
            {
                posX = Math.Abs(posX);
            }

            if ((Canvas.GetTop(bola) + bola.Height) < (Canvas.GetTop(bloque) + (bloque.Height / 2)))
            {
                if (posY > 0)
                {
                    posY *= -1;
                }
            }
            else
            {
                posY = Math.Abs(posY);
            }
        }
    }
}
