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
    public class Management<I> : Ibloques_management<I> where I : class
    {
        public List<I> listaObjetos { get; set; }
        public Management()
        {
            listaObjetos = new List<I>();
        }

        public void destruir(int id)
        {
            listaObjetos.RemoveAt(id);
        }

        public void mostrar(bool mostrar)
        {
           
        }

        public void posicionar(float posX, float posY)
        {
            Console.WriteLine("posicionado");
        }

        public void anadir_valores(int numGolpes, int tamano)
        {
            if (listaObjetos.Count > 0)
            {
               listaObjetos.Clear();
            }
            /*
            for (int i = 0; i < num_bloques; i++) { 
                Bloque = new Bloque();
                Bloque.numeroGolpes = numGolpes;
                Bloque.tamano = tamano;
                Bloque.id = i;
                listaObjetos.Add(Bloque);
            }
            */
        }
        public void anadir_valores()
        {
        }

        public void mostrar_datos()
        {
            foreach (var item in listaObjetos)
            {
                Console.WriteLine(item.ToString());
            }
            
        }

        public void destruir()
        {
            Console.WriteLine("se va destruir");
        }

        public void anadir(I objeto)
        {
            listaObjetos.Add(objeto);
        }
    }
}
