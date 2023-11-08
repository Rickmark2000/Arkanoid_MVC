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
        private Ifiguras_management<Rectangle> bloques_management;
        private int num_bloques;
        private Shape bola, plataforma, bloque;


        public Diseño(int num_bloques)
        {
            this.num_bloques = num_bloques;
        }
       

        public void crear_piezas()
        {
            bloque = Figuras_factory.crear_figura(TipoFigura.Rectangulo);
            bola = Figuras_factory.crear_figura(TipoFigura.Rectangulo);
            plataforma = Figuras_factory.crear_figura(TipoFigura.Rectangulo);



        }
    }

}
