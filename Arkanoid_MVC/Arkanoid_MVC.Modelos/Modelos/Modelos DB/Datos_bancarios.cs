using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos { 
    public class Datos_bancarios
    {
    
        public int Id { get; set; }
        public int id_Usuario { get; set; }
        public DateTime f_caducidad { get; set; }
        public string numeroTarjeta { get; set; }

        public string entidad { get; set; }

        public Datos_bancarios(int id,int id_Usuario, DateTime f_caducidad, string numeroTarjeta, string entidad)
        {
            this.Id = id;
            this.id_Usuario = id_Usuario;
            this.f_caducidad = f_caducidad;
            this.numeroTarjeta = numeroTarjeta;
            this.entidad = entidad;
        }
    }
}
