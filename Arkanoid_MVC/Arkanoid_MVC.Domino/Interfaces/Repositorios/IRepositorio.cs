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

        Task eliminar(Entity entity);

        Entity buscar(Entity entity);

        Task leer();

    }
}
