using System;

namespace Proyecto3_PilaLlamadas
{
    public class PilaLlamadas
    {
        private Nodo? cima; 

        public PilaLlamadas()
        {
            cima = null; 
        }

        public bool EstaVacia()
        {
            return cima == null;
        }

        public void RegistrarLlamada(string nombreFuncion)
        {
            Llamada nuevaLlamada = new Llamada(nombreFuncion);
            Nodo nuevoNodo = new Nodo(nuevaLlamada);

            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;

            Console.WriteLine($"\n[+] Llamada registrada: Entrando a {nombreFuncion}()");
        }

        public void FinalizarLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila de llamadas está vacía. No hay funciones que finalizar.");
                return;
            }

            Console.WriteLine($"\nRegresando de: {cima!.Dato.NombreFuncion}()");
            cima = cima.Siguiente;
        }

        public void AtenderLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nNo hay llamadas activas.");
                return;
            }

            Console.Write("\nAtendiendo contexto actual de ejecución en la función: ");
            cima!.Dato.Mostrar();
            Console.WriteLine();
        }

        public void MostrarLlamadasActivas()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila de llamadas está vacía.");
                return;
            }

            Console.WriteLine("\n--- Pila de llamadas (Call Stack) ---");
            Nodo? actual = cima;
            int i = 1;
            while (actual != null)
            {
                Console.Write($"{i}. ");
                actual.Dato.Mostrar();
                Console.WriteLine();
                actual = actual.Siguiente;
                i++;
            }
        }

        public void RecuperarUltimaLlamada()
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nNo hay llamadas en la pila.");
                return;
            }

            Console.Write("\nÚltima llamada activa (Cima): ");
            cima!.Dato.Mostrar();
            Console.WriteLine();
        }

        public void BuscarLlamada(string nombreBuscado)
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila está vacía.");
                return;
            }

            Nodo? actual = cima;
            int posicion = 1;
            bool encontrado = false;

            while (actual != null)
            {
                if (actual.Dato.NombreFuncion.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\n¡Función '{nombreBuscado}' encontrada en la pila (Posición {posicion} desde la cima)!");
                    encontrado = true;
                    break;
                }
                actual = actual.Siguiente;
                posicion++;
            }

            if (!encontrado)
            {
                Console.WriteLine($"\nLa función '{nombreBuscado}' no se encuentra activa en este momento.");
            }
        }

        public void EliminarLlamada(string nombreEliminar)
        {
            if (EstaVacia())
            {
                Console.WriteLine("\nLa pila está vacía.");
                return;
            }

            if (cima!.Dato.NombreFuncion.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nEliminando y finalizando llamada de la cima: {cima.Dato.NombreFuncion}()");
                cima = cima.Siguiente;
                return;
            }

            Nodo? actual = cima;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.NombreFuncion.Equals(nombreEliminar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nEliminando función '{nombreEliminar}' de la pila de llamadas.");
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }

            Console.WriteLine($"\nFunción '{nombreEliminar}' no encontrada en la pila.");
        }
    }
}