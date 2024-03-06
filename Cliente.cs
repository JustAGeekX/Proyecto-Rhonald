using System;
using System.Collections.Generic;
using System.Text;

namespace Clases{

    class Cliente{

        public string Nombre {get; set;}

        public char Genero {get; set;}

        public int Edad {get; set;}

        public string Prioridad {get; set;}

        public Cliente(string Nombre, char Genero, int Edad, string Prioridad){
            this.Nombre = Nombre;
            this.Genero = Genero;
            this.Edad = Edad;
            this.Prioridad = Prioridad;
        }
    }
}