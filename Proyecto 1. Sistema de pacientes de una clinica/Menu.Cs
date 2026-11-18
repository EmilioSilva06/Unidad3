using Proyecto1_Clinica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Clinica
{
    internal class Menu
    {
        static Cola pacientes = new Cola();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("=====CLINICA=====");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Atender pacientes");
                Console.WriteLine("3. Mostrar pacientes");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: "); // Usar Write en lugar de WriteLine para que quede al lado

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Registrar();
                            break;

                        case 2:
                            Atender();
                            break;

                        case 3:
                            pacientes.Mostrar(); // Corregido a 'M' mayúscula
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

        static void Registrar()
        {
            Console.Clear();
            Console.WriteLine("--- Registrar Paciente ---");

            Console.Write("Expediente: ");
            int expediente = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Prioridad: ");
            int prioridad = int.Parse(Console.ReadLine());

            // Asegúrate de que el constructor de Paciente reciba estos parámetros en orden correcto
            Paciente paciente = new Paciente(expediente, nombre, edad, prioridad);

            pacientes.Encolar(paciente);

            Console.WriteLine("\n¡Paciente registrado con éxito!");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static void Atender()
        {
            Console.Clear();
            Console.WriteLine("--- Atender Paciente ---");

            Paciente? paciente = pacientes.Desencolar();

            if (paciente == null)
            {
                Console.WriteLine("No hay pacientes en espera.");
            }
            else
            {
                Console.WriteLine("Paciente atendido con éxito:");
                Console.WriteLine(paciente); 
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}