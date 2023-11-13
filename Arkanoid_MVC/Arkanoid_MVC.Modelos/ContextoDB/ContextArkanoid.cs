
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.ContextoDB
{
    public class ContextArkanoid<I> : DbContext where I : class
    {
        private string _context;
        public DbSet<I> jugadores { get; set; }
        public DbSet<I> Puntuaciones { get; set; }
        public DbSet<I> passwords { get; set; }
        public DbSet<I> datosBancarios { get; set; }
        public DbSet<I> Usuarios { get; set; }


        public ContextArkanoid(string context)
        {
            this._context = context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            AppDomain.CurrentDomain.SetData("DataDirectory", proyectoRaiz);
            optionsBuilder.UseSqlServer(_context);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
