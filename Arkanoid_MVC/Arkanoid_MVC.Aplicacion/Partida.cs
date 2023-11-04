using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces;

namespace ArkanoidProyecto.Controladores
{
    public class Partida : Iinformacion
    {
        private bool pausar = false;
        private bool parar = false;
        private int cont = 0;

        public void iniciar_partida()
        {
            while (!parar)
            {
                if (pausar)
                {
                    while (pausar)
                    {
                        Console.WriteLine("Partida pausada");
                        Thread.Sleep(2000);

                    }
                }
                else
                {
                    Console.WriteLine("Partida iniciada");

                    Thread.Sleep(2000);
                    cont++;
                    Console.WriteLine(cont.ToString());
                }
                   
            }
            
        }

        public void pausar_partida(bool pausar)
        {
            this.pausar = pausar;
        }

        public void terminar_partida()
        {
            parar = true;
        }
    }
}
