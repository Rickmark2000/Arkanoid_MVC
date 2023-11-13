﻿using ArkanoidProyecto.Modelo.Clases_Atómicas;
using ArkanoidProyecto.Modelo.Interfaces.Repositorios;
using ArkanoidProyecto.Modelo.Patron_repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Infraestructura.Repositorios
{
    public class UsuariosRepositorio<I> : IRepositorio<I> where I : Usuario
    {
        private readonly ContextArkanoid<I> context;
        public List<I> listaObjetos { get; }

        public UsuariosRepositorio(string conexion)
        {
            context = new ContextArkanoid<I>(conexion);
            listaObjetos = context.Usuarios.ToList();
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
            context.Usuarios.Remove(jugador);
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
            context.passwords.Add(entity);
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