using System;
using System.Collections.Generic;

namespace GestionTareas
{
    // Clase que administra un conjunto de tareas
    public class GestorTareas
    {
        // Lista para almacenar las tareas
        private List<Tarea> tareas;

        // Pila para historial de tareas completadas (última en completarse, primera en mostrarse)
        private Stack<Tarea> historialCompletadas;

        // Diccionario para acceso rápido a tareas por título (tabla hash)
        private Dictionary<string, Tarea> indicePorTitulo;

        // Constructor: inicializa las estructuras
        public GestorTareas()
        {
            tareas = new List<Tarea>();
            historialCompletadas = new Stack<Tarea>();
            indicePorTitulo = new Dictionary<string, Tarea>();
        }

        // Método para agregar una nueva tarea
        public void AgregarTarea(string titulo, string descripcion, int prioridad)
        {
            if (indicePorTitulo.ContainsKey(titulo))
            {
                Console.WriteLine(" Ya existe una tarea con ese título.");
                return;
            }

            Tarea nueva = new Tarea(titulo, descripcion, prioridad);
            tareas.Add(nueva);
            indicePorTitulo[titulo] = nueva;

            Console.WriteLine(" Tarea agregada correctamente.");
        }

        // Método para mostrar todas las tareas pendientes
        public void MostrarTareasPendientes()
        {
            Console.WriteLine("\n📋 Tareas pendientes:\n");
            foreach (var tarea in tareas)
            {
                if (!tarea.Completada)
                {
                    tarea.Mostrar();
                }
            }
        }

        // Método para completar una tarea por título
        public void CompletarTarea(string titulo)
        {
            if (indicePorTitulo.TryGetValue(titulo, out Tarea? tarea))
            {
                if (tarea == null)
                {
                    Console.WriteLine(" No se encontró la tarea (valor nulo).");
                    return;
                }

                if (!tarea.Completada)
                {
                    tarea.MarcarComoCompletada();
                    historialCompletadas.Push(tarea);
                    Console.WriteLine(" Tarea marcada como completada.");
                }
                else
                {
                    Console.WriteLine(" Esa tarea ya estaba completada.");
                }
            }
            else
            {
                Console.WriteLine(" No se encontró ninguna tarea con ese título.");
            }


        }

        // Método para mostrar el historial de tareas completadas 
        public void MostrarHistorial()
        {
            Console.WriteLine("\n📜 Historial de tareas completadas:\n");
            foreach (var tarea in historialCompletadas)
            {
                tarea.Mostrar();
            }
        }

        // Método que simula inteligencia artificial 
        private int PredecirPrioridad(string descripcion)
        {
            descripcion = descripcion.ToLower();

            if (descripcion.Contains("urgente") || descripcion.Contains("hoy") || descripcion.Contains("ya") || descripcion.Contains("inmediato") || descripcion.Contains("rapido"))
                return 1; // Alta prioridad

            if (descripcion.Contains("importante") || descripcion.Contains("esta semana") || descripcion.Contains("mañana") || descripcion.Contains("pronto") || descripcion.Contains("despues"))
                return 2; // Prioridad media

            return 3; // Prioridad baja
        }

        // Método público que se puede usar desde Program.cs
        public int GetPrioridadAutomatica(string descripcion)
        {
            return PredecirPrioridad(descripcion);
        }
    }
}