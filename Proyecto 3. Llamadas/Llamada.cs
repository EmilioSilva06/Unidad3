using System;
namespace Proyecto3_PilaLlamadas
{
    public class Llamada
    {
        public string NombreFuncion { get; set; }

        public Llamada(string nombreFuncion)
        {
            NombreFuncion = nombreFuncion;
        }

        public void Mostrar()
        {
            System.Console.Write($"{NombreFuncion}()");
        }
    }
}