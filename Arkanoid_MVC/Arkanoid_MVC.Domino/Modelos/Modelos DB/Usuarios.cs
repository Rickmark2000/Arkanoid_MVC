using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Clases_Atómicas
{
    public class Usuarios
    { 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre {  get; set; }
        public string apellido {  get; set; }
        public string email {  get; set; }
        public string usuario {  get; set; }

        public Usuarios(int id,string nombre, string apellido, string email, string usuario)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.usuario = usuario;
        }

    }
}
