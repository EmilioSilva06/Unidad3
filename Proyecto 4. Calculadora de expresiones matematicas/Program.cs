using System;

namespace Practica4_Calculadora
{
    internal class Program
    {
        static int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;

            if (operador == '*' || operador == '/' || operador == '%') 
                return 2;

            if (operador == '^')
                return 3;

            return 0;
        }

        static string InfijaAPostfija(string expresion)
        {
            Pila pila = new Pila();
            string salida = "";

            for (int i = 0; i < expresion.Length; i++)
            {
                char caracter = expresion[i];

                if (caracter == ' ') continue; 

                if (char.IsDigit(caracter))
                {
                    string numero = "";
                    while (i < expresion.Length && char.IsDigit(expresion[i]))
                    {
                        numero += expresion[i];
                        i++;
                    }
                    i--; 
                    salida += numero + " "; 
                }
                else if (caracter == '(')
                {
                    pila.Apilar(caracter);
                }
                else if (caracter == ')')
                {
                    while (!pila.Vacia() && pila.Tope() != '(')
                    {
                        salida += pila.Desapilar() + " ";
                    }
                    pila.Desapilar(); 
                }
                else if ("+-*/%^".Contains(caracter))
                {
                    while (!pila.Vacia() && Prioridad(pila.Tope()) >= Prioridad(caracter))
                    {
                        salida += pila.Desapilar() + " ";
                    }
                    pila.Apilar(caracter);
                }
            }

            while (!pila.Vacia())
            {
                salida += pila.Desapilar() + " ";
            }

            return salida.Trim();
        }

        static double EvaluarPostfija(string postfija)
        {
            
            return 0; 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la expresion infija: ");
            string expresion = Console.ReadLine();

            string postfija = InfijaAPostfija(expresion);
            Console.WriteLine($"Postfija: {postfija}");

            Console.ReadKey();
        }
    }
}

