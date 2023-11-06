
using Arkanoid.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Patron_repositorio
{
    public class ContextArkanoid:DbContext
    {
        private string _context;
        public DbSet<Jugadores> jugadores { get; set; }
        public ContextArkanoid(string context)
        {
            this._context = context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;" +
              "AttachDbFilename=C:\\Users\\ricardsanchez\\AppData\\Local\\Microsoft" +
              "\\Microsoft SQL Server Local DB\\Instances" +
              "\\MSSQLLocalDB\\Arkanoid.mdf;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
