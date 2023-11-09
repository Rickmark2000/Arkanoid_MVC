using ArkanoidProyecto.Controladores;
using ArkanoidProyecto.Modelo;
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
    public class PlataformaDiseno : Diseno
    {
        public PlataformaDiseno(Figura figura) : base(figura)
        {
        }

        public override Shape Implementar(ref Canvas element)
        {
            throw new NotImplementedException();
        }
    }
}
