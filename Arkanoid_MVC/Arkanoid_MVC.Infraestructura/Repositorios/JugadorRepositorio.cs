

using Arkanoid.Dominio.Modelos;
using ArkanoidProyecto.Modelo.Interfaces;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
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
            return listaObjetos.Find(n => n == entity);
        }

        public I buscar(int value)
        {
            return listaObjetos.Find(n => n.id == value);
        }

        public void eliminar(I entity)
        {
            I jugador = buscar(entity);
            context.jugadores.Remove(jugador);
            context.SaveChanges();

        }

        public List<I> leer()
        {
            return listaObjetos;
        }

        public void registrar(I entity)
        {
            while (repetido(entity.id))
            {
                entity.id++;
            }
            context.jugadores.Add(entity);
            context.SaveChanges();

        }

        public bool repetido(I entity)
        {
            return listaObjetos.Any(e => e.Equals(entity));
        }

        public bool repetido(int entity)
        {
            return listaObjetos.Any(e => e.id.Equals(entity));
        }
    }
}
