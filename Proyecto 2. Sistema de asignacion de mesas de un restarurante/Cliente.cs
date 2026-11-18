//Este proyecto esta directamente relacionado con una de las practicas propuestas por el temario: simular una lista de espera para la asignacion de mesas de un restaunrante
using System;

namespace Proyecto2_Restaurante
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public int Persona { get; set; }

        public Cliente(string nombre, int persona)
        {
            Nombre = nombre;
            Persona = persona;

        }
        public override string ToString()
        {
            return $"{Nombre}-{Persona}personas";
        }
    }
}