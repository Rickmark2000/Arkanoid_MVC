using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IPartida
    {
        void preparar_partida(double Width, double Height, Canvas CanvasJuego, UIElement ventana);
        void iniciar_partida();
    }
}
