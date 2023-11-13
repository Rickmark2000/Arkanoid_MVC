using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public class Jugadores
    {
     
        public int id {  get; set; }
        public int idUsuario{ get; set; }

        public int puntuacion { get; set; }

        public string nombre {  get; set; }

        public int vidas {  get; set; }

        public Jugadores(int id,int idUsuario, int puntuacion, string nombre, int vidas)
        {
            this.id = id;
            this.idUsuario = idUsuario;
            this.puntuacion = puntuacion;
            this.nombre = nombre;
            this.vidas = vidas;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return nombre + " "+puntuacion;
        }
    }
}
