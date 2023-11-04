using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkanoidProyecto.Modelo;

namespace ArkanoidProyecto.Modelo.Interfaces
{
    public interface Iinformacion
    {
        void iniciar_partida();
        void terminar_partida();
        void pausar_partida(bool pausar);
    }
}
