using System;

namespace GestionTareas
{
    // Esta clase representa una Tarea individual del sistema de gestión
    public class Tarea
    {
        // Propiedad: título de la tarea
        public string Titulo { get; set; }

        // Propiedad: una descripción corta de la tarea
        public string Descripcion { get; set; }

        // Propiedad: número que indica la prioridad (1: alta, 2: media, 3: baja)
        public int Prioridad { get; set; }

        // Propiedad: indica si la tarea fue completada o no
        // Solo se puede modificar desde dentro de la clase (por eso es private set)
        public bool Completada { get; private set; }

        // Constructor: se ejecuta cuando se crea una nueva tarea
        public Tarea(string titulo, string descripcion, int prioridad)
        {
            // Asignamos los valores que recibe el constructor a las propiedades de la tarea
            Titulo = titulo;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Completada = false;                     // Por defecto, una tarea nueva no está completada
        }

        // Método para marcar la tarea como completada
        public void MarcarComoCompletada()
        {
            Completada = true;                      // Cambia el estado a "completada"
        }

        // Método para mostrar la información de la tarea por consola
        public void Mostrar()
        {
            // Creamos un texto que muestre si la tarea está completada o pendiente
            string estado = Completada ? "✅ Completada" : "⏳ Pendiente";

            // Mostramos la información de la tarea en consola
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Prioridad: {Prioridad}"); // 1 = alta, etc.
            Console.WriteLine($"Estado: {estado}");
            Console.WriteLine("------------------------------"); // Línea separadora
        }
    }
}