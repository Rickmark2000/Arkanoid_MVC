using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Patron_observer
{
    public class Comprobar_colisiones : IObservador_colision<Rectangle>
    {

        public EstadoBola estado(Rectangle ball, Canvas element, Rectangle plataforma, Rectangle[] bloques)
        {
            EstadoBola estado = EstadoBola.nada;

            if (detectar_colision_muro(ball, element))
            {
                estado = EstadoBola.pared;
            }
            else if (detectar_colision_plataforma(ball, plataforma))
            {
                estado = EstadoBola.EnPlataforma;
            }
            else if (detectar_fuera_limite(ball, element))
            {
                estado = EstadoBola.fuera;
            }
            else if (detectar_colision_bloque(ball, bloques))
            {
                estado = EstadoBola.choqueBloque;
            }
            else if (detectar_colision_techo(ball))
            {
                estado = EstadoBola.techo;
            }
            else
            {
                estado = EstadoBola.nada;
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
            List<Rectangle> listaBloques = bloques.ToList();
            List<Rect> colision_bloques = new List<Rect>();

            listaBloques.ForEach(bloque =>
            {
                colision_bloques.Add(new Rect(Canvas.GetLeft(bloque), Canvas.GetTop(bloque), bloque.Width, bloque.Height));
            });

            if(colision_bloques.Any( rect => rect.IntersectsWith(bola))){
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

    }
}
