namespace Proyecto3_PilaLlamadas
{
    public class Nodo
    {
        public Llamada Dato { get; set; }
        public Nodo? Siguiente { get; set; } // Permitimos nulo con ?

        public Nodo(Llamada llamada)
        {
            Dato = llamada;
            Siguiente = null; // Asignación explícita para evitar el warning
        }
    }
}