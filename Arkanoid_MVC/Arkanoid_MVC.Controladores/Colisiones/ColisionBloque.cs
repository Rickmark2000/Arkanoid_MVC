using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using Arkanoid_MVC.Modelos.Interfaces;

namespace Arkanoid_MVC.Controladores.Colisiones
{
    public class ColisionBloque
    {
        public Rectangle Colision_Bloque(Ifiguras_management<Rectangle> bloques, Canvas element, Ellipse bola)
        {
            Rectangle bloque = detectar_colision_bloque(bola, bloques,element);
            if (bloque != null)
            {
                element.Children.Remove(bloque);
                bloques.eliminar(bloque);
                return bloque;
            }
            else
            {
                return null;
            }
                
        }


        private Rectangle detectar_colision_bloque(Ellipse ball, Ifiguras_management<Rectangle> bloques_management, Canvas element)
        {
            Rect rect_bola = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
            Rect rect_plataforma;

            foreach (Rectangle bloque in bloques_management.ObtenerList())
            {
                rect_plataforma = new Rect(Canvas.GetLeft(bloque), Canvas.GetTop(bloque), bloque.Width, bloque.Height);
                if (rect_plataforma.IntersectsWith(rect_bola))
                {
                    return bloque;
                }
            }
            return null;
        }


        
    }
}
