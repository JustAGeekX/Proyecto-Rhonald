using System;
using System.Collections.Generic;
using System.Text;
using Clases;

namespace Colas{

    class Nodo(Cliente Persona)
    {

        public Cliente Persona { get; set; } = Persona;

        public Nodo? Siguiente { get; set; } = null;
    }
}