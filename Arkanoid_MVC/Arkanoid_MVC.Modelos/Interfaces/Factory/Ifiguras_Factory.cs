using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface Ifiguras_Factory<Objeto> where Objeto : Shape
    {
        Objeto crear();

    }
}
