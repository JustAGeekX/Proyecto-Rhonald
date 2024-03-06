using System;
using System.Collections.Generic;
using System.Text;
using Clases;
using Colas;

namespace Programa{

    class Programa{

        static Cola[,] Colas = new Cola[2,5];
        static Cliente[] Atendiendo = new Cliente[2];
        static Doctor[] Doctores = new Doctor[2];
        static string[] Prioridades = new string[] {"Accidente Aparatoso", "Infarto", "Afeccion Respiratoria", "Parto", "Normal"};

        static void Main(string[] args){
            for (int i = 0; i < Colas.GetLength(0); i++){
                for(int j = 0; j < Colas.GetLength(1); j++){
                    Colas[i,j] = new Cola();
                }
            }
            
            Doctores[0] = new Doctor("Rhonald", "Adultos");
            Doctores[1] = new Doctor("Jose", "Niños");
    
            Menu();
        }

        static void Menu(){
            int op = -1;
            do{

            Console.WriteLine("HOSPITAL EL RAZETTI (SALA DE EMERGENCIAS)");
            Console.WriteLine("1. Ingresar Paciente");
            Console.WriteLine("2. Atender Paciente");
            Console.WriteLine("3. Reporte de las Colas de Espera");
            Console.WriteLine("4. Retirar Paciente");
            Console.WriteLine("0. Salir del Programa");
            Console.Write("Ingrese la Opcion: ");
            try{
                op = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException){
                Console.WriteLine("Formato Invalido. Intente Nuevamente");
                continue;
            }

            switch(op){
                case 1:
                    Agregar();
                    break;
                case 2:
                    Atender();
                    break;
                case 3:
                    Mostrar();
                    break;
                case 4:
                    Retirar();
                    break;
                case 0:
                    Console.WriteLine("Programa Finalizado...");
                    break;
                default: Console.WriteLine("Opcion Invalida. Ingrese Nuevamente");
                    break;
                }
            }while(op != 0);
        }

        static void Agregar(){
            string nombre;
            int edad;
            char genero;
            Random random = new Random();
            int Priority = random.Next(0,5);
            string Prioridad = Prioridades[Priority];

            Console.WriteLine(Priority);
                    
            do{
                Console.Write("Nombre del Paciente: ");
                nombre = Console.ReadLine();
                if(nombre.Length == 0){
                    Console.WriteLine("Debe ingresar un nombre valido");
                }
            }while(nombre.Length == 0);

            do{
                Console.Write("Genero del Paciente ((M) Masculino, (F) Femenino):");
                try{
                    genero = Char.ToUpper((char)Console.ReadLine()[0]);
                }
                catch(IndexOutOfRangeException){
                    Console.WriteLine("Por favor, Intente Nuevamente");
                    genero = '.';
                    continue;
                }
                if(genero != 'F' && genero != 'M'){
                    Console.WriteLine("Debe ingresar un genero valido");
                }
            }while(genero != 'F' && genero != 'M');

            do{
                Console.Write("Edad del Paciente: ");
                try{
                    edad = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException){
                    Console.WriteLine("Fomato Invalido");
                    edad = -1;
                }

                if(edad < 0 || edad > 150){
                    Console.WriteLine("Debe ingresar una edad valida");
                }
            }while(edad < 0 || edad > 150);

            if((genero != 'F' || edad < 13 || edad > 50) && Priority == 3){
                Priority = random.Next(0,5);
                Prioridad = Prioridades[Priority];
            }

            Cliente nuevo = new Cliente(nombre, genero, edad, Prioridad);
            Nodo paciente = new Nodo(nuevo);

            if(edad<18){
                Colas[1,Priority].Encolar(paciente);
            }
            else{
                Colas[0,Priority].Encolar(paciente);
            }            
        }

        static void Atender(){
            int op = -1;

            do{
                Console.WriteLine("El paciente a atender es: ");
                Console.WriteLine("1. Adulto ");
                Console.WriteLine("2. Niño");
                Console.WriteLine("Escoja: ");
                try{
                    op = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException){
                    Console.WriteLine("Valor Invalido. Ingrese Nuevamente");
                    continue;
                }
                if(op !=1 && op != 2){
                    Console.WriteLine("Opcion incorrecta. Ingrese nuevamente");
                }
            }while(op !=1 && op != 2);

            int i = --op;
            if(Atendiendo[i] == null && Doctores[i].Disponibilidad == true){
                for(int j = 0; j < Colas.GetLength(1); j++){
                    if(!Colas[i,j].Vacia()){
                        Atendiendo[i] = Colas[i,j]._inicio.Persona;
                        Colas[i,j].Desencolar();
                        Doctores[i].Disponibilidad = false;
                        break;
                    }
                }
            }
            else{
                Console.WriteLine($"No puede ingresar. El Doctor {Doctores[i].Nombre} no esta disponible");
            }

            if(Atendiendo[i] == null){
                Console.WriteLine("No hay pacientes en espera");
            }
        }

        static void Retirar(){
            int op;
            if(Atendiendo[0] == null && Atendiendo[1] == null){
                Console.WriteLine("No hay pacientes siendo atendidos");
            }
            else{
                do{
                    Console.Write("Adulto: ");
                    if(Atendiendo[0] == null){
                        Console.WriteLine("No hay nadie siendo atendido");
                    }
                    else{
                        Console.WriteLine($"{Atendiendo[0].Nombre} (Edad: {Atendiendo[0].Edad}, Prioridad: {Atendiendo[0].Prioridad})");
                    }
        
                    Console.Write("Niño: ");
                    if(Atendiendo[1] == null){
                        Console.WriteLine("No hay nadie siendo atendido");
                    }
                    else{
                        Console.WriteLine($"{Atendiendo[1].Nombre} (Edad: {Atendiendo[1].Edad}, Prioridad: {Atendiendo[1].Prioridad})");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Que paciente desea retirar?:\n1.Adulto\n2.Niño\n3.Ninguno");
                    Console.WriteLine("Escoja: ");
                    try{
                        op = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException){
                        Console.WriteLine("Valor Invalido. Ingrese Nuevamente");
                        op = -1;
                        continue;
                    }
                    if(op < 1 || op > 3 ){
                        Console.WriteLine("Opcion incorrecta. Ingrese nuevamente");
                    }
                }while(op < 1 || op > 3);
                
                if(op != 3){
                    int i = --op;
                    if(Atendiendo[i] == null){
                        Console.WriteLine("No hay nadie siendo atendido en esta especializacion");
                    }
                    else{
                        Console.WriteLine($"El paciente {Atendiendo[i].Nombre} ha sido atendido con exito");
                        Atendiendo[i] = null;
                        Doctores[i].Disponibilidad = true;
                    }
                }
            }
        }

        static void MostrarColas(int x){
            for(int i = 0; i < Colas.GetLength(1); i++){
                Console.Write($"{Prioridades[i]}: ");
                if(Colas[x,i].Vacia()){
                    Console.WriteLine("Esta cola está vacía");
                }
                else{
                    Nodo? actual = Colas[x,i]._inicio;
                    while (actual != null)
                    {
                        Console.Write($"{actual.Persona.Nombre}, ");
                        actual = actual.Siguiente;
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Mostrar(){
            Console.WriteLine("Colas de Adultos:");
            MostrarColas(0);
            Console.WriteLine();
            Console.WriteLine("Colas de Niños:");
            MostrarColas(1);

            Console.WriteLine();

            Console.WriteLine("Pacientes siendo atendidos:");
            if(Atendiendo[0] == null){
                Console.WriteLine("Adultos: No hay pacientes siendo atendidos");
            }
            else{
                Console.WriteLine($"Adultos: El paciente {Atendiendo[0].Nombre} esta siendo atendido por el doctor {Doctores[0].Nombre}");
            }

            if(Atendiendo[1] == null){
                Console.WriteLine("Niños: No hay pacientes siendo atendidos");
            }
            else{
                Console.WriteLine($"Niños: El paciente {Atendiendo[1].Nombre} esta siendo atendido por el doctor {Doctores[1].Nombre}");
            }
            
            Console.WriteLine();
        }
    }
}