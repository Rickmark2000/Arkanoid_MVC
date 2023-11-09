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
        private Ifiguras_management<Rectangle> bloquesManagement;

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
            IRepositorio<Jugadores> jugador_Repositorio = new Jugador_repositorio(connectionString);

            setupGame();
            
        }



        private void setupGame()
        {

            posBolaInicialY = Canvas.GetTop(ball);
            posBolaInicialX = Canvas.GetLeft(ball);

            plataformaPosX = Canvas.GetLeft(plataformalista);


            colocar_bloques(12);
            colocar_bola();
       


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

        public void colocar_bola()
        {
            Figura_Velocidad bola = new Figura_Velocidad(TipoFigura.Elipse);
            bola.ancho = 50;
            bola.alto = 50;
            bola.posicionX = Width / 2;
            bola.posicionY = Height / 2;
            bolaDiseño = new DisenoElipse(bola);
            this.bola = (Ellipse)bolaDiseño.Implementar(ref CanvasJuego, Colors.Red, Colors.Black, 2);
        }

        public void colocar_bloques(int num_bloques)
        {
            bloques = new Rectangle[num_bloques];
            bloquesManagement = new BloquesManagement();
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
                if (tamano_total + bloqueFigura.ancho > Width)
                {
                    tamano_total = 0;
                    bloqueFigura.posicionX = 26;
                    bloqueFigura.posicionY += bloqueFigura.alto + separacionY;

                }

                bloqueDiseño = new DisenoRectangulo(bloqueFigura);
                bloques[i] = (Rectangle)bloqueDiseño.Implementar(ref CanvasJuego, Colors.Aqua, Colors.Black, 2);
                bloquesManagement.anadir(bloques[i]);

                tamano_total += bloqueFigura.ancho + separacionX;
                bloqueFigura.posicionX += separacionX + bloqueFigura.ancho;


            }
        }
    }
}
