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

namespace Arkanoid_MVC
{
   
    public partial class MainWindow : Window
    {
        private bool isGameOver;
        private DispatcherTimer timer;

        private double posBolaInicialX, posBolaInicialY;
        double actualBolaX = 2, actualBolaY = 2;
        private double posPlataformaX = 0;

        private Juego juego = new Juego();

        private Rectangle[] bloques;
        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private Ifiguras_management<Rectangle> bloquesManagement;

        private Controles controles;
  
        private Comprobar_colisiones comprobarColisiones;
        private HelperColision helperColision;

        private Enum estado;

        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            controles = new Controles(ventana,6);
            comprobarColisiones = new Comprobar_colisiones();
            helperColision = new HelperColision();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            IRepositorio<Jugadores> jugador_Repositorio = new Jugador_repositorio(connectionString);

            setupGame();
            
        }

        private void setupGame()
        {
           bola = juego.colocar_bola(Width, Height, CanvasJuego);
           bloquesManagement = juego.colocar_bloques(9, CanvasJuego, Width);
           plataforma_jugador = juego.colocar_plataforma(Width, Height, CanvasJuego);

            posBolaInicialY = Canvas.GetTop(bola);
            posBolaInicialX = Canvas.GetLeft(bola);

            posPlataformaX = Canvas.GetLeft(plataforma_jugador);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (!isGameOver)
            {
                Canvas.SetLeft(plataforma_jugador, posPlataformaX);
                controles.mover(plataforma_jugador, ref posPlataformaX, CanvasJuego);


                Canvas.SetTop(bola, posBolaInicialY += actualBolaY);
                Canvas.SetLeft(bola, posBolaInicialX += actualBolaX);
                estado = comprobarColisiones.estado(bola, CanvasJuego, plataforma_jugador, bloques);
                helperColision.ColisionBola(estado, ref actualBolaX, ref actualBolaY);


                isGameOver = estado.ToString() == EstadoBola.fuera.ToString() ? true : false;
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
