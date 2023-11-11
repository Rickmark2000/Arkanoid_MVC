using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Arkanoid_MVC.Aplicacion;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces;
using Arkanoid.Dominio.Modelos;
using ArkanoidProyecto.Controladores.Patron_observer;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using ArkanoidProyecto.Controladores.Controles;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows;

namespace ArkanoidProyecto.Controladores
{
    public class Partida : IPartida
    {
        private bool isGameOver = false, pausar = false;
        private int tiempo = 0;
        private Canvas CanvasJuego;

        private double BolaInicialX, BolaInicialY, PlataformaInicialX;
        double actualBolaX = 2, actualBolaY = 2;

        private Juego juego = new Juego();

        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private Ifiguras_management<Rectangle> bloques;

        private IObservador_colision<Ellipse, Rectangle> comprobarColisiones = new ObservarColision();
        private IRepositorio<Jugadores> jugador_Repositorio;

        private Controles_jugador controles;


        private Colisiones_figuras colision = new Colisiones_figuras();

        public Partida(int time, Canvas CanvasJuego)
        {
            this.CanvasJuego = CanvasJuego;
            this.tiempo = time;
        }

        public void preparar_partida(double Width, double Height, Canvas CanvasJuego, UIElement ventana)
        {
            bola = juego.crear_bola(Width, Height, CanvasJuego);
            plataforma_jugador = juego.crear_plataforma(Width, Height, CanvasJuego);
            bloques = juego.crear_bloques(9, CanvasJuego, Width);

            controles = new Controles_jugador(ventana, 6);

            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }
        public void iniciar_partida()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                while (!isGameOver)
                {
                    Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
                    controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);


                    Canvas.SetTop(bola, BolaInicialY += actualBolaY);
                    Canvas.SetLeft(bola, BolaInicialX += actualBolaX);


                    colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
                    colision.colisiona(bola, ref actualBolaX, ref actualBolaY, CanvasJuego, ref isGameOver);
                   // colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref s ,CanvasJuego, bloques);

                    Thread.Sleep(tiempo);
                }
            });
        }


        private void terminar_partida()
        {
            isGameOver = true;
        }

        private void pausar_partida(bool pausar)
        {
            this.pausar = pausar;
        }
    }
}
