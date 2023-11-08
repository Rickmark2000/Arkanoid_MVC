using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ArkanoidProyecto.Controladores.Managements
{
    public class BloquesManagement : Ifiguras_management<Rectangle>
    {
        public List<Rectangle> listaObjetos { get; set; }
        public BloquesManagement()
        {
            listaObjetos = new List<Rectangle>();
        }

        public void anadir(Rectangle objeto)
        {
            listaObjetos.Add(objeto);
        }

        public Rectangle buscar(int value)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Rectangle objeto)
        {
           listaObjetos.Remove(objeto);
        }
    }
}
