using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Dominio.Modelos
{
    public class Jugadores
    {
        public Jugadores(int id, int idUsuario, int puntuacion, string nombre, int vidas)
        {
            this.id = id;
            this.idUsuario = idUsuario;
            this.puntuacion = puntuacion;
            this.nombre = nombre;
            this.vidas = vidas;
        }

        public int id {  get; set; }
        public int idUsuario{ get; set; }

        public int puntuacion { get; set; }

        public string nombre {  get; set; }

        public int vidas {  get; set; }

        public override string ToString()
        {
            return nombre + " "+puntuacion;
        }
    }
}
