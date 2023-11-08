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
    public class Comprobar_colisiones : IObservador_colision<Rectangle>
    {

        public TipoEstado estado(Rectangle ball, Canvas element, Rectangle plataforma, Rectangle[] bloques)
        {
            TipoEstado estado = TipoEstado.nada;

            if (detectar_colision_muro(ball, element))
            {
                estado = TipoEstado.pared;
            }
            else if (detectar_colision_plataforma(ball, plataforma))
            {
                estado = TipoEstado.EnPlataforma;
            }
            else if (detectar_fuera_limite(ball, element))
            {
                estado = TipoEstado.fuera;
            }
            else if (detectar_colision_bloque(ball, bloques))
            {
                estado = TipoEstado.choqueBloque;
            }
            else if (detectar_colision_techo(ball))
            {
                estado = TipoEstado.techo;
            }
            else
            {
                estado = TipoEstado.nada;
            }
            return estado;
        }

        private bool detectar_colision_techo(Rectangle ball)
        {

            if (Canvas.GetTop(ball) < 0)
            {
                return true;

               
            }
            else
            {
                return false;
            }
        }

        public bool detectar_colision_muro(Rectangle ball, Canvas CanvasJuego)
        {
            if (Canvas.GetLeft(ball) + ball.Width > CanvasJuego.Width || Canvas.GetLeft(ball) < 0)
            {
                return true;

            }
            else { return false; }
        }

        public bool detectar_colision_plataforma(Rectangle ball, Rectangle plataforma)
        {

            Rect sd = new Rect(Canvas.GetLeft(plataforma), Canvas.GetTop(plataforma), plataforma.Width, plataforma.Height);
            Rect SD2 = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
            bool colisiona = sd.IntersectsWith(SD2) == true ? true : false;
            return colisiona;

        }

        public bool detectar_fuera_limite(Rectangle ball, Canvas element)
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

        public bool detectar_colision_bloque(Rectangle ball, Rectangle[] bloques)
        {
            Rect bola = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);

            for (int i = 0; i < bloques.Length; i++)
            {
                Rect bloque = new Rect();
                if (bloques[i] != null)
                {
                    bloque = new Rect(Canvas.GetLeft(bloques[i]), Canvas.GetTop(bloques[i]), bloques[i].Width, bloques[i].Height);
                }

                if (bloque.IntersectsWith(bola))
                {
                    /*
                   
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
