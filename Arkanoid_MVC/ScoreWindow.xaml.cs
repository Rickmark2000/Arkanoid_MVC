using Arkanoid_MVC.Controladores.DB_Controller;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        private IRepositorio<Usuarios> usuarios;
        private IRepositorio<Passwords> password;
        public ScoreWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            jugadores = new JugadorRepositorio<Jugadores>(connectionString);
            puntuaciones = new PuntuacionRepositorio<Puntuaciones>(connectionString);
            usuarios = new UsuariosRepositorio<Usuarios>(connectionString);
            password = new PasswordRepository<Passwords>(connectionString);

            DB_Controller db_controller = new DB_Controller(connectionString);

            /*
            Usuarios u = new Usuarios(1, "Rick", "Sanchez Fernandez", "ricardo@gmail.com", "Rickmark");
            usuarios.registrar(u);
            Passwords p = new Passwords(1, 1, "pepe2023");
            password.registrar(p);
            Jugadores j = new Jugadores(1, 1, 23, "Rickamrk", 3);
            jugadores.registrar(j);
            Puntuaciones puntuacion = new Puntuaciones(1, 1, 23, 23);
            puntuaciones.registrar(puntuacion);
            */
            
            

            string consulta = "select u.Id,u.usuario,j.nombre,p.puntuacion,j.vidas " +
              "from jugadores as j inner join puntuaciones as p on p.idJugador = j.id inner" +
              " join Usuarios as u on u.Id = j.idUsuario WHERE j.nombre = 'Roriru'";

            string consulta2 = "select * " +
              "from jugadores";


            db_controller.realizar_consulta(consulta2,datos);

        }

        public void vaciar_db(DB_Controller db_controller)
        {
            db_controller.eliminar_tabla<Puntuaciones>(puntuaciones);
            db_controller.eliminar_tabla<Passwords>(password);
            db_controller.eliminar_tabla<Jugadores>(jugadores);
            db_controller.eliminar_tabla<Usuarios>(usuarios);
        }

    

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
