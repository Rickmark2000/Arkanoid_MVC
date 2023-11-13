using Arkanoid.Dominio.Modelos;
using Arkanoid_MVC.Infraestructura.Repositorios;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using ArkanoidProyecto.Modelo.Patron_repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Arkanoid_MVC
{
    /// <summary>
    /// Lógica de interacción para ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        private IRepositorio<Jugadores> jugadores;
        private IRepositorio<Puntuaciones> puntuaciones;
        public ScoreWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            jugadores = new JugadorRepositorio<Jugadores>(connectionString);
            puntuaciones = new PuntuacionRepositorio<Puntuaciones>(connectionString);
            Jugadores j = new Jugadores(1,1, 23, "Roriru", 3);
            jugadores.registrar(j);
            datos.ItemsSource = jugadores.leer();
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
