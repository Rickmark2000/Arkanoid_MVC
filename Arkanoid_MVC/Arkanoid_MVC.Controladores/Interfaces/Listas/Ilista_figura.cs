﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Interfaces
{
    public interface Ilista_figura<T>
    {
         List<T> listaObjetos { get;}
    }
}