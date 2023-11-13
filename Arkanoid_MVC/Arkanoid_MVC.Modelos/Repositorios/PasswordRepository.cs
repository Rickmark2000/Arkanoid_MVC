using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Repositorios
{
    public class PasswordRepository<I> : IRepositorio<I> where I : Passwords
    {
        private readonly ContextArkanoid<I> context;
        public List<I> listaObjetos { get; }

        public PasswordRepository(string conexion)
        {
            context = new ContextArkanoid<I>(conexion);
            listaObjetos = context.passwords.ToList();
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
            context.passwords.Remove(jugador);
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
