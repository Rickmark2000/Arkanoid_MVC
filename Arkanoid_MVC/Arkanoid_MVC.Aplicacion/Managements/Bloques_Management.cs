using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Managements
{
    public class Bloques_Management : Ibloques_management
    {
        public List<Bloque> listaObjetos { get; set; }
        private Bloque Bloque;
        private int num_bloques;
        public Bloques_Management(Bloque bloque, int num_bloques)
        {
            this.Bloque = bloque;
            this.num_bloques = num_bloques;
            listaObjetos = new List<Bloque>();
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
            for (int i = 0; i < num_bloques; i++) { 
                Bloque = new Bloque();
                Bloque.numeroGolpes = numGolpes;
                Bloque.tamano = tamano;
                Bloque.id = i;
                listaObjetos.Add(Bloque);
            }
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

    }
}
