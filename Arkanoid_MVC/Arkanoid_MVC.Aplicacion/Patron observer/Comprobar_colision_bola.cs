using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Patron_observer
{
    public class Comprobar_colision_bola:IObservador_colision<Bola>
    {
        private Bola bola;

        public Comprobar_colision_bola(Bola bola)
        {
            this.bola = bola;
        }

        public string estado(Bola entity)
        {
            string estado = "";

            if (detectar_colision_muro())
            {
                estado = TipoEstado.pared.ToString();
            }
            else if(detectar_colision_plataforma())
            {
                estado = TipoEstado.EnPlataforma.ToString();
            }
            else if (detectar_fuera_limite())
            {
                estado = TipoEstado.fuera.ToString();
            }else if (detectar_colision_bloque())
            {
                estado = TipoEstado.choqueBloque.ToString();
            }
            else
            {
                estado = "";
            }
            return estado;
        }

        public bool detectar_colision_muro()
        {
            return false;
        }

        public bool detectar_colision_plataforma()
        {
            return false;
        }

        public bool detectar_fuera_limite()
        {
            return false;
        }

        public bool detectar_colision_bloque()
        {
            return false;
        }

    }
}
