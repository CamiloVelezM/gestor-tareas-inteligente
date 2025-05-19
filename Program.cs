using System;

namespace GestionTareas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos el gestor de tareas
            GestorTareas gestor = new GestorTareas();
            int opcion = 0;

            // Bucle principal del programa
            do
            {
                // Limpiamos la pantalla y mostramos el menú con estilo
                Console.Clear();
                MostrarMenu();

                Console.Write("Seleccione una opción: ");
                string? entrada = Console.ReadLine();

                // Validamos que la entrada sea un número
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Entrada no válida. Presione una tecla para continuar...");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                Console.Clear(); // Limpiamos pantalla antes de cada acción

                switch (opcion)
                {
                    case 1:
                        // AGREGAR NUEVA TAREA
                        Console.WriteLine("🔹 AGREGAR NUEVA TAREA 🔹");

                        Console.Write("Título: ");
                        string? titulo = Console.ReadLine();

                        Console.Write("Descripción: ");
                        string? descripcion = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descripcion))
                        {
                            Console.WriteLine("❌ El título y la descripción no pueden estar vacíos.");
                            Console.ReadKey();
                            break;
                        }

                        // La prioridad se asigna automáticamente con IA simulada
                        int prioridad = gestor.GetPrioridadAutomatica(descripcion);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"🔍 Prioridad automática asignada: {prioridad}");
                        Console.ResetColor();

                        gestor.AgregarTarea(titulo, descripcion, prioridad);
                        Console.WriteLine("✅ Tarea agregada. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:
                        // MOSTRAR TAREAS PENDIENTES
                        Console.WriteLine("📋 TAREAS PENDIENTES:\n");
                        gestor.MostrarTareasPendientes();
                        Console.WriteLine("\n✅ Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3:
                        // MARCAR COMO COMPLETADA
                        Console.WriteLine("✅ COMPLETAR TAREA");
                        Console.Write("Título de la tarea: ");
                        string? tituloCompletar = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(tituloCompletar))
                        {
                            Console.WriteLine("❌ El título no puede estar vacío.");
                        }
                        else
                        {
                            gestor.CompletarTarea(tituloCompletar);
                        }

                        Console.WriteLine("✅ Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        // MOSTRAR HISTORIAL
                        Console.WriteLine("📜 HISTORIAL DE TAREAS COMPLETADAS:\n");
                        gestor.MostrarHistorial();
                        Console.WriteLine("\n✅ Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("👋 Gracias por usar SmartTask. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("❌ Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 5);
        }

        // Menú visual con bordes y colores
        static void MostrarMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║     SMARTTASK - GESTIÓN DE TAREAS ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine("║ 1. Agregar nueva tarea             ║");
            Console.WriteLine("║ 2. Mostrar tareas pendientes       ║");
            Console.WriteLine("║ 3. Marcar tarea como completada    ║");
            Console.WriteLine("║ 4. Ver historial de tareas         ║");
            Console.WriteLine("║ 5. Salir                           ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}