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
using System.Windows.Controls.Primitives;

namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            Title = "Menu principal";
            empezar.Content = "Empezar partida";
            salir.Content = "Salir";
            score.Content = "Score Board";
        
        }

        public void empezar_partida(object sender, RoutedEventArgs e)
        {
            Juego_arkanoid juego = new Juego_arkanoid();
            juego.Show();
            this.Close();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void score_Click(object sender, RoutedEventArgs e)
        {
            ScoreWindow score = new ScoreWindow();
            score.Show();

        }
    }
}
