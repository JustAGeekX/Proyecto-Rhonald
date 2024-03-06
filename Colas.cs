using System;
using System.Collections.Generic;
using System.Text;

namespace Colas{

    class Cola{

        public Nodo? _inicio;
        int Cantidad = 0;
        int Max = 10;

        public void Encolar(Nodo x){
            if (Llena()){
                Console.WriteLine("La cola de pacientes esta llena.");
            }
            else{
                if (_inicio == null){
                    _inicio = x;
                }
                else{
                    Nodo aux = Ultimo(_inicio);
                    aux.Siguiente = x;
                }
                Cantidad++;
            }
        }

        public void Desencolar(){
            if (Vacia()){
                Console.WriteLine("No hay pacientes en esta Cola");
            }
            else{
                _inicio = _inicio.Siguiente;
                Cantidad--;
            }
        }

        public bool Vacia(){
            return (_inicio == null);
        }

        private static Nodo Ultimo(Nodo x){
            if (x.Siguiente == null){
                return x;
            }
            else{
                return Ultimo(x.Siguiente);
            }
        }

        public bool Llena(){
            return Cantidad >= Max;
        }
    }
}