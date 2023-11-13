using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo
{
    public class Puntuaciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }

        public int idjugador {  get; set; }
        public int puntuacion { get; set; }
        public int puntuacion_record { get; set; }

        public Puntuaciones(int id,int idjugador, int puntuacion, int puntuacion_record)
        {
            this.id = id;
            this.idjugador = idjugador;
            this.puntuacion = puntuacion;
            this.puntuacion_record = puntuacion_record;
        }

        public override string ToString()
        {
            return $"puntos:{puntuacion}, record:{puntuacion_record}";
        }
    }
}
