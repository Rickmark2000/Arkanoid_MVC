using Arkanoid_MVC.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Management
{
    public class BloquesManagement : Ifiguras_management<Rectangle>
    {

        public List< Rectangle> listaObjetos { get; }

        public BloquesManagement()
        {
            listaObjetos = new List<Rectangle>();
        }

        public void anadir(Rectangle objeto)
        {
            listaObjetos.Add(objeto);
        }

        public Rectangle buscar(Rectangle value)
        {
            if (listaObjetos.Contains(value))
            {
                return listaObjetos.Find(n=> n.Equals(value));
            }
            else { return null; }
        }

        public void eliminar(Rectangle value)
        {
            listaObjetos.Remove(value);
        }

        public List<Rectangle> ObtenerList()
        {
            return listaObjetos.ToList();
        }
        
    }
}
