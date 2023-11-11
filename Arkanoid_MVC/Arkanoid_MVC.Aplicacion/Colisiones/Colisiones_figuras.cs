using Arkanoid_MVC.Aplicacion.Colisiones;
using Arkanoid_MVC.Aplicacion.Helpers;
using ArkanoidProyecto.Controladores.Managements;
using ArkanoidProyecto.Controladores.Patron_observer;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Aplicacion
{
    public class Colisiones_figuras
    {
        private IObservador_colision<Ellipse, Rectangle> observar = new ObservarColision();
        private ColisionInterseccion interseccion = new ColisionInterseccion();


        public void colisiona(Ellipse bola,ref double posX,ref double posY,Canvas element,ref bool gameOver)
        {
            IObservador_colision<Ellipse, Rectangle> observar = new ObservarColision();
            EColision tipo = observar.estado(bola,element);

            switch (tipo)
            {
                case EColision.ColisionHorizontal:
                    posX *= -1;
                    break;
                case EColision.ColisionVertical:
                    posY *= -1;
                    break;
                case EColision.fuera:
                    gameOver = true;
                    break;
            }
        }

        public void colisiona(Ellipse bola, ref double posX, ref double posY,Rectangle plataforma)
        {
    
            EColision tipo = observar.estado(bola, plataforma);

            switch (tipo)
            {
                case EColision.EnPlataforma:
                    interseccion.Colision_interseccionY(bola, plataforma, ref posY);
                 
                    break;
         
            }
        }

        public void colisiona(Ellipse bola, ref double posX, ref double posY,Canvas element,Ifiguras_management<Rectangle> bloques)
        {
            ColisionBloque colisionBloque = new ColisionBloque();
            Rectangle bloque = colisionBloque.Colision_Bloque(bloques,element,bola);

            if(bloque!=null)
            {
                interseccion.Colision_interseccionY(bola, bloque,ref posY);
                interseccion.Colision_interseccionX(bola,bloque,ref posX);
            }
        }

    }
}
