using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2_Restaurante
{
    internal class Program
    {
        static Cola espera = new Cola();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=== RESTAURANTE ===");
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Asignar mesa");
                Console.WriteLine("3. Mostrar espera");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: "); 

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Agregar();
                            break;

                        case 2:
                            AsignarMesa();
                            break;

                        case 3:
                            espera.Mostrar();
                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                }

            } while (opcion != 0); 
        }

        static void Agregar()
        {
            Console.Clear();
            Console.WriteLine("--- Agregar Cliente ---");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Numero de personas: ");
            int personas = int.Parse(Console.ReadLine() ?? "0");

            espera.Encolar(new Cliente(nombre, personas));

            Console.WriteLine("\nCliente agregado con éxito.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void AsignarMesa()
        {
            Console.Clear();
            Console.WriteLine("--- Asignar Mesa ---");

            Cliente? cliente = espera.Desencolar();

            if (cliente == null)
            {
                Console.WriteLine("No hay clientes en espera.");
            }
            else
            {
                Console.WriteLine($"Mesa asignada al cliente: {cliente}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}