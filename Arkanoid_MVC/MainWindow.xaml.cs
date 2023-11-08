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
        Rectangle[] rect = new Rectangle[8];
        Controles controles;
        Diseño diseño;
        Comprobar_colisiones comprobar;
        ColisionHelper helperColision;
        EstadoBola estado;

        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            controles = new Controles(ventana);
            diseño = new Diseño(8);
            comprobar = new Comprobar_colisiones();
            helperColision = new ColisionHelper();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            Jugador_repositorio jugador_Repositorio = new Jugador_repositorio(connectionString);

            setupGame();
            
        }



        private void setupGame()
        {


            anchoPantalla = SystemParameters.PrimaryScreenWidth;
            altoPantalla = SystemParameters.PrimaryScreenHeight;

            posBolaInicialY = Canvas.GetTop(ball);
            posBolaInicialX = Canvas.GetLeft(ball);


            CanvasJuego.Width = anchoPantalla;
            CanvasJuego.Height = altoPantalla;

            plataformaPosX = Canvas.GetLeft(plataforma);

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


            Canvas.SetTop(ball, posBolaInicialY += actualBolaY);
            Canvas.SetLeft(ball, posBolaInicialX += actualBolaX);

            Canvas.SetLeft(plataforma, plataformaPosX);
            Canvas.GetTop(plataforma);


            isGameOver = estado ==EstadoBola.fuera ? true : false;

            estado = comprobar.estado(ball,CanvasJuego,plataforma,rect);
            helperColision.ColisionBola(estado,ref actualBolaX,ref actualBolaY);

            if (!isGameOver)
            {
                controles.mover(plataforma, ref plataformaPosX, CanvasJuego);
            }
           
       
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasJuego.Width = e.NewSize.Width;
            CanvasJuego.Height = e.NewSize.Height;

        }
    }
}
