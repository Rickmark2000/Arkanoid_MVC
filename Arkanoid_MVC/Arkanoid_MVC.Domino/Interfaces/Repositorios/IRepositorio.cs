using Arkanoid.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Repositorios
{
    public interface IRepositorio<Entity>: Ilista_figura<Entity>, Icomprobar_repetido<Entity> where Entity : class
    {
        Task registrar(Entity entity);

        Task eliminar(Entity entity);

        Entity buscar(Entity entity);

        List<Entity> leer();

    }
}
