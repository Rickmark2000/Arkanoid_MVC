using Arkanoid_MVC.Controladores.Diseño_Figuras;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Controladores.Management;
using Arkanoid_MVC.Modelos.Enum;
using Arkanoid_MVC.Modelos.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Juego
{
    public class Juego
    {

        public Ellipse crear_bola(double with,double height, Canvas canvas_juego)
        {
            DisenoElipse bolaDiseño;
            Figura_Velocidad bola = new Figura_Velocidad(TipoFigura.Elipse);
            bola.ancho = 35;
            bola.alto = 35;
            bola.posicionX = with / 2;
            bola.posicionY = height / 2;
            bolaDiseño = new DisenoElipse(bola);
            return (Ellipse)bolaDiseño.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }

        public BloquesManagement crear_bloques(int num_bloques, Canvas canvas_juego,double with)
        {
            Rectangle[] bloques = new Rectangle[num_bloques];
            Ifiguras_management<Rectangle> bloquesManagement = new BloquesManagement();
            DisenoRectangulo bloqueDiseño;
            Figura_SinVelocidad bloqueFigura = new Figura_SinVelocidad(TipoFigura.Rectangulo);

            bloqueFigura.ancho = 110;
            bloqueFigura.alto = 30;
            bloqueFigura.posicionX = 26;
            bloqueFigura.posicionY = 44;

            int separacionX = 11;
            int separacionY = 11;
            double tamano_total = 0;

            for (int i = 0; i < bloques.Length; i++)
            {
                if (tamano_total + bloqueFigura.ancho > with)
                {
                    tamano_total = 0;
                    bloqueFigura.posicionX = 26;
                    bloqueFigura.posicionY += bloqueFigura.alto + separacionY;
                }

                bloqueDiseño = new DisenoRectangulo(bloqueFigura);
                bloques[i] = (Rectangle)bloqueDiseño.Implementar(ref canvas_juego, Colors.Aqua, Colors.Black, 2);
                bloquesManagement.anadir(bloques[i]);

                tamano_total += bloqueFigura.ancho + separacionX;
                bloqueFigura.posicionX += separacionX + bloqueFigura.ancho;


            }

            return (BloquesManagement)bloquesManagement;
        }


        public Rectangle crear_plataforma(double with, double height, Canvas canvas_juego)
        {
            DisenoRectangulo dieseñoPlataforma;
            Figura_Velocidad plataforma = new Figura_Velocidad(TipoFigura.Rectangulo);
            plataforma.ancho = 160;
            plataforma.alto = 20;
            plataforma.posicionX = with / 2;
            plataforma.posicionY = height-60;
            dieseñoPlataforma = new DisenoRectangulo(plataforma);
            return (Rectangle)dieseñoPlataforma.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }
    }
}
