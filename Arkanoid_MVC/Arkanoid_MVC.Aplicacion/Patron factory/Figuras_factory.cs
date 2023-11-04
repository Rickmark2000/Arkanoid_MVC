using ArkanoidProyecto.Controladores.Managements;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo.Interfaces.Factory;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Patron_factory
{
    public abstract class Figuras_factory : Ifiguras_Factory<Figura>
    {
        public static Figura crear_figura(TipoFigura tipo)
        {
            Figura figura = null;
            switch (tipo)
            {
                case TipoFigura.Bloque:
                    figura = new Bloques_Factory().crear();
                    break;
                case TipoFigura.Plataforma:
                    figura = new Plataformas_Factory().crear();
                    break;
                case TipoFigura.Bola:
                    figura = new Bolas_Factory().crear();
                    break;
            }

            return figura;
        }
        public abstract Figura crear(int tamano);
        public abstract Figura crear();

    }
}
