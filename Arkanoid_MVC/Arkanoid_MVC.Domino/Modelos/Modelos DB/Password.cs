using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Clases_Atómicas
{
    public class Password
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_Usuario { get; set; }
        public string password { get; set; }

        public Password(int id,int id_Usuario, string password)
        {
            this.id = id;
            this.id_Usuario = id_Usuario;
            this.password = password;
        }
    }
}
