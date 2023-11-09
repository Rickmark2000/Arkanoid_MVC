using ArkanoidProyecto.Controladores;
using ArkanoidProyecto.Controladores.Patron_factory;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Enumeracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Aplicacion.Diseño
{
    public class DisenoBloque : Diseno
    {
        private int numBlques;

        public DisenoBloque(Figura figura, int numBloques) : base(figura)
        {
            this.numBlques = numBloques;
        }

        public override Shape Implementar(ref Canvas element)
        {
            Rectangle plataforma = (Rectangle)Figuras_factory.crear_figura(figura.tipoFigura);
            return null;
        }
    }
}
