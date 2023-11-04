using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Controladores.Managements
{
    public class Plataformas_Management : Iplataformas_management
    {
        private Plataforma Plataforma;

        public Plataformas_Management(Plataforma plataforma)
        {
            this.Plataforma = plataforma;
        }

        public void anadir_valores(int velocidad, float tamano)
        {
            Plataforma.tamano = tamano;
            Plataforma.velocidad = velocidad;
        }

        public void destruir()
        {
            
        }

        public void mostrar(bool mostrar)
        {
           
        }

        public void mostrar_datos()
        {
            Console.WriteLine(Plataforma.ToString());
        }

        public void posicionar(float posX, float posY)
        {
            
        }
    }
}
