using System;
using System.Collections.Generic;
using System.Text;

namespace Clases{

    class Doctor{

        public string Nombre {get; set;}

        public string Especializacion {get; set;}

        public bool Disponibilidad {get; set;}

        public Doctor(string Nombre, string Especializacion){
            this.Nombre = Nombre;
            this.Especializacion = Especializacion;
            this.Disponibilidad = true;
        }
    }
}