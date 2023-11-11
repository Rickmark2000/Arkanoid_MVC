﻿using ArkanoidProyecto.Modelo;
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
            return listaObjetos.Find(n => n == entity);
        }

        public void eliminar(I entity)
        {
            I jugador = buscar(entity);
            context.Puntuaciones.Remove(jugador);
            context.SaveChanges();

        }

        public List<I> leer()
        {
            return listaObjetos;
        }

        public void registrar(I entity)
        {
            context.Puntuaciones.Add(entity);
            context.SaveChanges();

        }

        public bool repetido(I entity)
        {
            return listaObjetos.Any(e => e.Equals(entity));
        }
    }
}