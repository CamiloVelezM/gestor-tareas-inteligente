using System;

namespace GestionTareas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una instancia del gestor de tareas
            GestorTareas gestor = new GestorTareas();

            int opcion = 0;

            // Bucle principal del programa
            do
            {
                // Mostramos el menú en consola
                Console.WriteLine("\n===== Menú de Gestión de Tareas =====");
                Console.WriteLine("1. Agregar nueva tarea");
                Console.WriteLine("2. Mostrar tareas pendientes");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Ver historial de tareas completadas");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                // Leemos la opción del usuario
                string? entrada = Console.ReadLine();
                if (entrada == null)
                {
                    Console.WriteLine("No se ingresó ninguna opción.");
                    continue;
                }

                // Intentamos convertir a número
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                    continue;
                }

                // Usamos un switch para ejecutar cada opción
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título de la tarea: ");
                        string? titulo = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(titulo))
                        {
                            Console.WriteLine(" El título no puede estar vacío.");
                            break;
                        }
                        // Verificamos si el título ya existe

                        Console.Write("Ingrese la descripción: ");
                        string? descripcion = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(descripcion))
                        {
                            Console.WriteLine(" La descripción no puede estar vacía.");
                            break;
                        }
                        // Verificamos si la descripción ya existe


                        // Ya no pedimos prioridad al usuario, la calculamos automáticamente
                        int prioridad = gestor.GetPrioridadAutomatica(descripcion);
                        Console.WriteLine($"🔍 Prioridad asignada automáticamente: {prioridad}");

                        gestor.AgregarTarea(titulo, descripcion, prioridad);
                        break;

                    case 2:
                        gestor.MostrarTareasPendientes();
                        break;

                    case 3:
                        Console.Write("Ingrese el título de la tarea a completar: ");
                        string? tituloCompletar = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(tituloCompletar))
                        {
                            Console.WriteLine(" El título no puede estar vacío.");
                            break;
                        }
                        else
                        {
                            // Verificamos si el título ya existe
                            gestor.CompletarTarea(tituloCompletar);
                        }
                        break;

                    case 4:
                        gestor.MostrarHistorial();
                        break;

                    case 5:
                        Console.WriteLine("👋 Saliendo del programa. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine(" Opción no válida. Intente de nuevo.");
                        break;
                }

            } while (opcion != 5);
        }
    }
}