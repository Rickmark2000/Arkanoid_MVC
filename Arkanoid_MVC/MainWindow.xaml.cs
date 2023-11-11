using Arkanoid.Dominio.Modelos;
using ArkanoidProyecto.Controladores;
using ArkanoidProyecto.Modelo.Patron_repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Data.SqlClient;
using ArkanoidProyecto.Controladores.Controles;
using ArkanoidProyecto.Controladores.Patron_observer;
using ArkanoidProyecto.Modelo.Enumeracion;
using Arkanoid_MVC.Aplicacion;
using Arkanoid_MVC.Domino.Interfaces;
using Arkanoid_MVC.Aplicacion.Diseño;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Controladores.Patron_factory;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using Arkanoid_MVC.Domino.Modelos;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using ArkanoidProyecto.Controladores.Managements;
using ArkanoidProyecto.Modelo.Interfaces;
using Arkanoid_MVC.Aplicacion.Helpers;
using Arkanoid_MVC.Aplicacion.Colisiones;
using System.Threading;
using Arkanoid_MVC.Infraestructura.Repositorios;

namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {
        private bool isGameOver;
        private DispatcherTimer timer;

        private double BolaInicialX, BolaInicialY, PlataformaInicialX;
        double actualBolaX = 2, actualBolaY = 2;

        private Juego juego = new Juego();

        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private Ifiguras_management<Rectangle> bloques;

        private IObservador_colision<Ellipse, Rectangle> comprobarColisiones = new ObservarColision();
        private IRepositorio<Jugadores> jugador_Repositorio;
        private IRepositorio<Puntuaciones> puntuacion_repositorio;

        private Controles_jugador controles;

        
        private Colisiones_figuras colision = new Colisiones_figuras();

        public MainWindow()
        {
            InitializeComponent();

            

            controles = new Controles_jugador(ventana, 6);
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            jugador_Repositorio = new JugadorRepositorio<Jugadores>(connectionString);
            puntuacion_repositorio = new PuntuacionRepositorio<Puntuaciones>(connectionString);

      puntuacion_repositorio.registrar(new Puntuaciones(4,1,23,23));

            label.Content = puntuacion_repositorio.leer().Count;
            prepararJuego();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            timer.Tick += Timer_Tick;
            timer.Start();
            

        }

        private void prepararJuego()
        {
            bola = juego.crear_bola(Width, Height, CanvasJuego);
            plataforma_jugador = juego.crear_plataforma(Width, Height, CanvasJuego);
            bloques = juego.crear_bloques(9, CanvasJuego, Width);

            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (!isGameOver)
            {
                Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
                controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);


                Canvas.SetTop(bola, BolaInicialY += actualBolaY);
                Canvas.SetLeft(bola, BolaInicialX += actualBolaX);


                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, CanvasJuego, ref isGameOver);
                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, CanvasJuego, bloques);

            }
            else
            {
                timer.Stop();

            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasJuego.Width = e.NewSize.Width;
            CanvasJuego.Height = e.NewSize.Height;

        }

    }
}
