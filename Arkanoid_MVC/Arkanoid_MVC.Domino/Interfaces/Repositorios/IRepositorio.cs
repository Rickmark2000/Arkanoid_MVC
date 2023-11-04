using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Repositorios
{
    public interface IRepositorio<Entity> where Entity : class
    {
        public Task registrar(Entity entity);

        public Task registrar(List<Entity> entity);

        public Task eliminar(Entity entity);

        public Task buscar(Entity entity);

        public Task leer();

    }
}
