using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces
{
    public interface Ilista_figura<T>
    {
        public List<T> listaObjetos { get; set; }
    }
}
