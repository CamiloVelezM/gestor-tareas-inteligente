// Importamos el framework de pruebas xUnit
using Xunit;

// Importamos el namespace donde están nuestras clases (Tarea, GestorTareas, etc.)
using GestionTareas;

namespace GestionTareas.Tests // Espacio de nombres para las pruebas
{
    // Esta clase contiene todas las pruebas del sistema SmartTask
    public class PruebasSmartTask
    {
        // ✅ PRUEBA 1: Prioridad automática para una tarea urgente
        [Fact] // Marca esta función como una prueba unitaria
        public void Prioridad_Urgente_EsAlta()
        {
            // Creamos una instancia del gestor
            var gestor = new GestorTareas();

            // Probamos una descripción urgente
            var prioridad = gestor.GetPrioridadAutomatica("Esto es urgente y debe hacerse hoy");

            // Verificamos que el resultado sea 1 (alta prioridad)
            Assert.Equal(1, prioridad);
        }

        // ✅ PRUEBA 2: Verifica que una tarea pueda marcarse como completada
        [Fact]
        public void Tarea_SeMarcaComoCompletada()
        {
            // Creamos una nueva tarea
            var tarea = new Tarea("Tarea Test", "Descripción", 2);

            // Marcamos la tarea como completada
            tarea.MarcarComoCompletada();

            // Verificamos que ahora esté marcada como completada (true)
            Assert.True(tarea.Completada);
        }

        // ✅ PRUEBA 3: Verifica que no se puedan agregar tareas duplicadas
        [Fact]
        public void No_Duplicar_Tareas_Mismo_Titulo()
        {
            // Creamos una instancia del gestor
            var gestor = new GestorTareas();

            // Agregamos una tarea con título "T1"
            gestor.AgregarTarea("T1", "Descripción", 1);

            // Intentamos agregar otra con el mismo título (debería ser ignorada)
            gestor.AgregarTarea("T1", "Otra descripción", 1);

            // Verificamos que solo se haya agregado una tarea
            Assert.Equal(1, gestor.ContarTareas()); // Este método debe existir en tu clase
        }

    }

}