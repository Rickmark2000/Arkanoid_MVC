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

namespace Arkanoid_MVC
{
   
    public partial class MainWindow : Window
    {
        bool goLeft;
        bool goRight;
        bool isGameOver;
        private DispatcherTimer timer;
        private double posicionX, posicionY;
        double altoPantalla;
        double anchoPantalla, velocidadX = 2, velocidadY = 2;
        private
            double posX = 0;
        int score;
        Rectangle[] rect = new Rectangle[8];
        Controles controles;
        Diseño diseño;
        Comprobar_colisiones comprobar;
        string estado;

        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            controles = new Controles(ventana);
            diseño = new Diseño(8);
            comprobar = new Comprobar_colisiones();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            Jugador_repositorio jugador_Repositorio = new Jugador_repositorio(connectionString);

            setupGame();
            
        }



        private void setupGame()
        {
            score = 0;


            anchoPantalla = SystemParameters.PrimaryScreenWidth;
            altoPantalla = SystemParameters.PrimaryScreenHeight;

            posicionY = Canvas.GetTop(ball);
            posicionX = Canvas.GetLeft(ball);


            CanvasJuego.Width = anchoPantalla;
            CanvasJuego.Height = altoPantalla;

            posicionX = Canvas.GetTop(ball);

            posX = Canvas.GetLeft(plataforma);

            for (int i = 0; i < rect.Length; i++)
            {
                rect[i] = (Rectangle)FindName("bloque" + (i + 1));
                rect[i].Fill = new SolidColorBrush(Colors.Red);

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
            label.Content = goLeft;
            Canvas.SetTop(ball, this.posicionY += velocidadY);
            Canvas.SetLeft(ball, this.posicionX += velocidadX);
            Canvas.SetLeft(plataforma, anchoPantalla / 2 - plataforma.Width / 2);
            Canvas.SetLeft(plataforma, posX);
            double posicionX = Canvas.GetLeft(plataforma);
            double posicionPlataforma = Canvas.GetLeft(plataforma);
            Canvas.GetTop(plataforma);

            estado =comprobar.estado(ball,CanvasJuego,plataforma,rect);
            controles.mover(plataforma, ref posX, CanvasJuego);

           

            


       
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasJuego.Width = e.NewSize.Width;
            CanvasJuego.Height = e.NewSize.Height;

        }
    }
}
