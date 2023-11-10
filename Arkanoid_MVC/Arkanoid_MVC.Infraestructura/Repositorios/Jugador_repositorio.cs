

using Arkanoid.Dominio.Modelos;
using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Patron_repositorio
{
    public class Jugador_repositorio : IRepositorio<Jugadores>,Ilista_figura<Jugadores>,Icomprobar_repetido<int>
    {
        private readonly ContextArkanoid context;
        public List<Jugadores> listaObjetos { get; set; }

        public Jugador_repositorio(string conexion)
        {
            context = new ContextArkanoid(conexion);
            listaObjetos = context.jugadores.ToList();
        }



        public Jugadores buscar(Jugadores entity)
        {
            Jugadores jugador;
            return jugador = listaObjetos.Find(n => n == entity);
        }

        public async Task eliminar(Jugadores entity)
        {
            Jugadores jugador;
            jugador = listaObjetos.Find(n => n == entity);
            context.jugadores.Remove(jugador);
            context.SaveChanges();
       
        }

        public async Task leer()
        {
            listaObjetos.ForEach(n => Console.WriteLine(n.ToString()));
        }

        public async Task registrar(Jugadores entity)
        {
            if (!repetido(entity.id))
            {
                context.jugadores.Add(entity);
                context.SaveChanges();
            }
       
        }

        public bool repetido(int entity)
        {
            return listaObjetos.Any(n => n.id == entity);
        }

    }
}
