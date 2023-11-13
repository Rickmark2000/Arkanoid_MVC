using Arkanoid.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidProyecto.Modelo.Interfaces.Repositorios
{
    public interface IRepositorio<Entity>: Ilista_figura<Entity>,Icomprobar_repetido<int> where Entity : class
    {
        void registrar(Entity entity);

        void eliminar(Entity entity);

        Entity buscar(Entity entity);

        Entity buscar(int value);

        List<Entity> leer();

    }
}
