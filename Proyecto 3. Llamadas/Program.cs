using System;

namespace Proyecto3_PilaLlamadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PilaLlamadas pila = new PilaLlamadas();
            int opcion;

            pila.RegistrarLlamada("Main");
            pila.RegistrarLlamada("MenuPrincipal");
            pila.RegistrarLlamada("RegistrarCliente");
            pila.RegistrarLlamada("BuscarCliente");

            do
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("    SIMULADOR DE PILA DE LLAMADAS (STACK) ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Registrar llamada");
                Console.WriteLine("2. Finalizar llamada (Regresar)");
                Console.WriteLine("3. Atender llamada actual");
                Console.WriteLine("4. Mostrar llamadas activas");
                Console.WriteLine("5. Recuperar última llamada");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese el nombre de la función a registrar: ");
                            string? nombreReg = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreReg))
                            {
                                pila.RegistrarLlamada(nombreReg);
                            }
                            break;

                        case 2:
                            pila.FinalizarLlamada();
                            break;

                        case 3:
                            pila.AtenderLlamada();
                            break;

                        case 4:
                            pila.MostrarLlamadasActivas();
                            break;

                        case 5:
                            pila.RecuperarUltimaLlamada();
                            break;

                        case 6:
                            Console.Write("\nIngrese el nombre de la función a buscar: ");
                            string? nombreBusc = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreBusc))
                            {
                                pila.BuscarLlamada(nombreBusc);
                            }
                            break;

                        case 7:
                            Console.Write("\nIngrese el nombre de la función a eliminar: ");
                            string? nombreEli = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nombreEli))
                            {
                                pila.EliminarLlamada(nombreEli);
                            }
                            break;

                        case 0:
                            Console.WriteLine("\nSaliendo del simulador de pila...");
                            break;

                        default:
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 0);
        }
    }
}