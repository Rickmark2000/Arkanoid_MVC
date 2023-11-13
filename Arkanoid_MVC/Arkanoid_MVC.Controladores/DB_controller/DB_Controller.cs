using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Arkanoid_MVC.Modelos.Interfaces;

namespace Arkanoid_MVC.Controladores.DB_Controller
{
    public class DB_Controller
    {
        private string contexto;

        public DB_Controller(string contexto)
        {
            this.contexto = contexto;
        }

        public void realizar_consulta(string consulta, System.Windows.Controls.DataGrid datos)
        {
            using (SqlConnection conexion = new SqlConnection(contexto))
            {
                var bindingSource = new BindingSource();
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    try
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adaptador);

                        DataTable table = new DataTable();
                        adaptador.Fill(table);
                        bindingSource.DataSource = table;
                        datos.ItemsSource = bindingSource;
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }

            }
        }

        public void eliminar_tabla<I>(IRepositorio<I> elements) where I:class
        {
            foreach(I element in elements.leer())
            {
                elements.eliminar(element);
            }
        }

  
    }
}
