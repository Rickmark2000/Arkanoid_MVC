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

namespace Arkanoid_MVC
{
   
    public partial class MainWindow : Window
    {
        bool isGameOver;
        private DispatcherTimer timer;
        private double posBolaInicialX, posBolaInicialY;
        double altoPantalla;
        double anchoPantalla, actualBolaX = 2, actualBolaY = 2;
        private double plataformaPosX = 0;
        int score = 0;

        Rectangle[] bloques;
        Rectangle plataforma;
        Ellipse bola;

        private IDisenoFigura plataformaDiseño, bolaDiseño, bloqueDiseño;

        private Controles controles;
  
        private Comprobar_colisiones comprobar;
        private HelperColision helperColision;

        private Enum estado;

        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            controles = new Controles(ventana,6);
            comprobar = new Comprobar_colisiones();
            helperColision = new HelperColision();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            Jugador_repositorio jugador_Repositorio = new Jugador_repositorio(connectionString);

            setupGame();
            
        }



        private void setupGame()
        {

            posBolaInicialY = Canvas.GetTop(ball);
            posBolaInicialX = Canvas.GetLeft(ball);

            plataformaPosX = Canvas.GetLeft(plataformalista);

            bloques = new Rectangle[8];

            for (int i = 0; i < bloques.Length; i++)
            {
                bloques[i] = (Rectangle)FindName("bloque" + (i + 1));
                bloques[i].Fill = new SolidColorBrush(Colors.Red);

            }


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            if (!isGameOver)
            {

                timer.Tick += Timer_Tick;

                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {


            Canvas.SetTop(ball, posBolaInicialY += actualBolaY);
            Canvas.SetLeft(ball, posBolaInicialX += actualBolaX);

            Canvas.SetLeft(plataformalista, plataformaPosX);
            Canvas.GetTop(plataformalista);


            

            estado = comprobar.estado(ball,CanvasJuego,plataformalista,bloques);
            isGameOver = estado.ToString() == EstadoBola.fuera.ToString() ? true : false;
            helperColision.ColisionBola(estado,ref actualBolaX,ref actualBolaY);

            if (!isGameOver)
            {
                controles.mover(plataformalista, ref plataformaPosX, CanvasJuego);
            }
           
       
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasJuego.Width = e.NewSize.Width;
            CanvasJuego.Height = e.NewSize.Height;

        }

        public void crear_pieza()
        {
            Figura_Velocidad f = new Figura_Velocidad(TipoFigura.Rectangulo);
            f.ancho = 50;
            f.alto = 50;
            f.posicionX = Width / 2;
            f.posicionY = Height / 2;
            bolaDiseño = new DisenoElipse(f);
            bola = (Ellipse)bolaDiseño.Implementar(ref CanvasJuego, Colors.Red, Colors.Black, 2);
        }
    }
}
