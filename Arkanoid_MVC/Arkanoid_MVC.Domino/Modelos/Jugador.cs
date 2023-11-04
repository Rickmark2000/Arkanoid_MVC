using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string nombre { get; set; }
        public int vidas { get; set; }
        public int idUsuario { get; set; }
        public Puntuacion puntuacion { get; set; }

        public Jugador(string nombre, int vidas)
        {
            this.nombre = nombre;
            this.vidas = vidas;
            puntuacion = new Puntuacion();
        }

        public Jugador(string nombre)
        {
            this.nombre = nombre;
            puntuacion = new Puntuacion();
        }

        public Jugador(int jugadorId, string nombre, int vidas)
        {
            JugadorId = jugadorId;
            this.nombre = nombre;
            this.vidas = vidas;
            puntuacion = new Puntuacion();
        }
        public Jugador()
        {
            puntuacion = new Puntuacion();
        }

        public override string ToString()
        {
            return $"El jugador {nombre}, tiene {vidas} vidas y la puntuacion es [{puntuacion.ToString()}]";
        }
    }
}
