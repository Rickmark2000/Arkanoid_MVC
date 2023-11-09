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

        public Dictionary<int, Rectangle> lista_figura { get; }

        public BloquesManagement()
        {
            lista_figura = new Dictionary<int, Rectangle>();
        }

        public void anadir(Rectangle objeto)
        {
            int id = lista_figura.Count;
            lista_figura.Add(id+1, objeto);
        }

        public Rectangle buscar(int value)
        {
            if (lista_figura.ContainsKey(value))
            {
                return lista_figura.First(n => n.Key == value).Value;
            }
            else { return null; }
        }

        public void eliminar(int value)
        {
            lista_figura.Remove(value);
        }

        public List<Rectangle> ObtenerList()
        {
            return lista_figura.Values.ToList();
        }
    }
}
