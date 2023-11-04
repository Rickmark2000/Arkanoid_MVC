using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Repositorios
{
    public interface IRepositorio<Entity> where Entity : class
    {
        Task registrar(Entity entity);

         Task registrar(List<Entity> entity);

        Task eliminar(Entity entity);

        Task buscar(Entity entity);

        Task leer();

    }
}
