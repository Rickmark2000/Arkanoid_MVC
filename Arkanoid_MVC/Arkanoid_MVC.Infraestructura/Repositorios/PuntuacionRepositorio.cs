using ArkanoidProyecto.Modelo;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using ArkanoidProyecto.Modelo.Patron_repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Infraestructura.Repositorios
{
    public class PuntuacionRepositorio<I> : IRepositorio<I> where I : Puntuaciones
    {
        private readonly ContextArkanoid<I> context;
        public List<I> listaObjetos { get; }

        public PuntuacionRepositorio(string conexion)
        {
            context = new ContextArkanoid<I>(conexion);
            listaObjetos = context.Puntuaciones.ToList();
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
            return listaObjetos;
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
