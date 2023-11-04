using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkanoidProyecto.Modelo.Enumeracion;

namespace ArkanoidProyecto.Modelo
{
    public class Bloque : Figura
    {

        public int numeroGolpes { get; set; }
        public int id { get; set; }

        public Bloque()
        {
            tipoFigura = TipoFigura.Bloque;
        }

        public Bloque(float tamano) : base(tamano)
        {

        }

        public Bloque(int tamano) : base(tamano) { tipoFigura = TipoFigura.Bola; }

        public override string ToString()
        {
            return $"Es :{tipoFigura}, con un id de {id} y {numeroGolpes} golpes restantes";
        }
    }
}
