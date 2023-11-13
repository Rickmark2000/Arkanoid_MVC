
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Controladores.Observer;
using Arkanoid_MVC.Modelos.Enum;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Colisiones
{
    public class ColisionAplicar
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

        public void colisiona(Ellipse bola, ref double posX, ref double posY,ref int score,Canvas element,Ifiguras_management<Rectangle> bloques)
        {
            ColisionBloque colisionBloque = new ColisionBloque();
            Rectangle bloque = colisionBloque.Colision_Bloque(bloques,element,bola);

            if(bloque!=null)
            {
                score++;
                interseccion.Colision_interseccionY(bola, bloque,ref posY);
                interseccion.Colision_interseccionX(bola,bloque,ref posX);
            }
        }

    }
}
