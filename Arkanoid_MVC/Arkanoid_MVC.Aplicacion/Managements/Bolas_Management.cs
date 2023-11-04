using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Managements
{
    public class Bolas_Management : Ibolas_management
    {
        private Bola bola;

        public Bolas_Management(Bola bola)
        {
            this.bola = bola;
        }

        public void anadir_valores(float fuerza, int velocidad, int tamano)
        {
            bola.fuerzaLanzado = fuerza;
            bola.velocidad = velocidad;
            bola.tamano = tamano;
        }

        public void destruir()
        {
        
        }

        public void mostrar(bool mostrar)
        {
          
        }

        public void mostrar_datos()
        {
            Console.WriteLine(bola.ToString());
        }

        public void posicionar(float posX, float posY)
        {
         
        }
    }
}
