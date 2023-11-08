using ArkanoidProyecto.Controladores.Managements;
using ArkanoidProyecto.Modelo.Enumeracion;
using ArkanoidProyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using ArkanoidProyecto.Controladores.Patron_factory;
using ArkanoidProyecto.Modelo.Interfaces;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores
{
    public class Diseño
    {

        private Ibolas_management bolas_management;
        private Iplataformas_management plataformas_management;
        private Ibloques_management bloques_management;
        private int num_bloques = 0;
        private Figura bola, plataforma, bloque;


        public Diseño(int num_bloques)
        {
            this.num_bloques = num_bloques;
        }

        private void crear_management(Figura figura)
        {
            switch (figura.tipoFigura)
            {
                case TipoFigura.Bloque:
                    bloques_management = new Management();
                    break;
                case TipoFigura.Plataforma:
                    plataformas_management = new Plataformas_Management((Plataforma)figura);
                    break;
                case TipoFigura.Bola:
                    bolas_management = new Bolas_Management((Bola)figura);
                    break;
            }
        }

        public void crear_piezas()
        {
            bloque = Figuras_factory.crear_figura(TipoFigura.Bloque);
            bola = Figuras_factory.crear_figura(TipoFigura.Bola);
            plataforma = Figuras_factory.crear_figura(TipoFigura.Plataforma);
            crear_management(bloque);
            crear_management(bola);
            crear_management(plataforma);


            bloques_management.anadir_valores(12,43);


            bloques_management.destruir(5);
            bloques_management.mostrar_datos();

        }
    }

}
