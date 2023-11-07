using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Patron_observer
{
    public class Comprobar_colisiones:IObservador_colision<Rectangle>
    {

        public string estado(Rectangle entity,Canvas element,Rectangle plataforma, Rectangle[] rect)
        {
            string estado = "";

            if (detectar_colision_muro(entity,element))
            {
                estado = TipoEstado.pared.ToString();
            }
            else if(detectar_colision_plataforma(entity,plataforma))
            {
                estado = TipoEstado.EnPlataforma.ToString();
            }
            else if (detectar_fuera_limite(entity,element))
            {
                estado = TipoEstado.fuera.ToString();
            }else if (detectar_colision_bloque(entity,rect))
            {
                estado = TipoEstado.choqueBloque.ToString();
            }
            else if (detectar_colision_techo(entity))
            {
                estado = TipoEstado.techo.ToString();
            }
            else
            {
                estado = "";
            }
            return estado;
        }

        private bool detectar_colision_techo(Rectangle ball)
        {

            if (Canvas.GetTop(ball) < 0)
            {
                return true;

                // velocidadY *= -1;
            }
            else
            {
                return false;
            }
        }

        public bool detectar_colision_muro(Rectangle ball,Canvas CanvasJuego)
        {
            if (Canvas.GetLeft(ball) + ball.Width > CanvasJuego.Width || Canvas.GetLeft(ball) < 0)
            {

                //velocidadX *= -1;
                return true;

            }
            else { return false; }
        }

        public bool detectar_colision_plataforma( Rectangle ball,Rectangle plataforma)
        {

            Rect sd = new Rect(Canvas.GetLeft(plataforma), Canvas.GetTop(plataforma), plataforma.Width, plataforma.Height);
            Rect SD2 = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);



            if (sd.IntersectsWith(SD2))
            {
                double ballCenterX = Canvas.GetLeft(ball) + ball.Width / 2;
                double platformCenterX = Canvas.GetLeft(plataforma) + plataforma.Width / 2;
               // velocidadY *= -1;
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool detectar_fuera_limite(Rectangle ball,Canvas element)
        {
            if (Canvas.GetTop(ball) + ball.Height >= (Math.Abs(element.Height - ball.Height)))
            {

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool detectar_colision_bloque( Rectangle ball, Rectangle[] rect)
        {
            Rect SD2 = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);

            for (int i = 0; i < rect.Length; i++)
            {
                Rect eas = new Rect();
                if (rect[i] != null)
                {
                    eas = new Rect(Canvas.GetLeft(rect[i]), Canvas.GetTop(rect[i]), rect[i].Width, rect[i].Height);
                }

                if (eas.IntersectsWith(SD2))
                {
                    /*
                    velocidadY *= -1;
                    CanvasJuego.Children.Remove(rect[i]);
                    score++;
                    rect[i] = null;
                    */
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}
