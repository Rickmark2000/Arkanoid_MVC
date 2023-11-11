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
using Arkanoid_MVC.Domino.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ArkanoidProyecto.Controladores
{
    public abstract class Diseno:IDisenoFigura
    {
        protected Figura figura;

        public Diseno(Figura figura)
        {
            this.figura = figura;
        }

        public abstract Shape Implementar(ref Canvas element,Color color_fondo,Color color_borde,int grosor_borde);
    }

}
