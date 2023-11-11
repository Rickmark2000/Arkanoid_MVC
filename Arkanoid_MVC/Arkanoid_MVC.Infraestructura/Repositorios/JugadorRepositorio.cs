

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
    public class JugadorRepositorio<I> : IRepositorio<I> where I : Jugadores
    {
        private readonly ContextArkanoid<I> context;
        public List<I> listaObjetos { get; }

        public JugadorRepositorio(string conexion)
        {
            context = new ContextArkanoid<I>(conexion);
            listaObjetos = context.jugadores.ToList();
        }



        public I buscar(I entity)
        {
            I jugador;
            return jugador = listaObjetos.Find(n => n == entity);
        }

        public async Task eliminar(I entity)
        {
            I jugador;
            jugador = listaObjetos.Find(n => n == entity);
            context.jugadores.Remove(jugador);
            context.SaveChanges();
       
        }

        public List<I> leer()
        {
          return  listaObjetos;
        }

        public async Task registrar(I entity)
        {
            if (!repetido(entity))
            {
                context.jugadores.Add(entity);
                context.SaveChanges();
            }
       
        }

        public bool repetido(I entity)
        {
            return listaObjetos.Contains(entity);
        }
    }
}
