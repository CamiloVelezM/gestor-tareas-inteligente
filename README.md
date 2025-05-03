# Gestor de Tareas Inteligente

INTEGRANTES
 
  
  WUDEISON TOVAR CRUZ


  JUAN PABLO MARIN

  
  ANDRES CAMILO VELEZ MONCADA
  


Este proyecto consiste en una aplicación de consola desarrollada en C#, diseñada para ayudar al usuario a organizar y priorizar tareas de forma eficiente. Implementa estructuras de datos clásicas como pilas, colas y tablas hash, e incluye un componente de inteligencia artificial que predice automáticamente la prioridad de una tarea a partir del análisis de su descripción.



## Funciones implementadas

- Crear tareas con título, descripción y prioridad
- Listar tareas pendientes
- Marcar tareas como completadas
- Visualizar historial de tareas completadas
- Simulación de predicción de prioridad según la descripción

## Estructuras de datos utilizadas

- Lista: almacenamiento principal de tareas activas
- Pila: historial de tareas completadas
- Diccionario (tabla hash): acceso rápido a tareas por título

  Inteligencia Artificial (Machine Learning):
El sistema analiza el texto de la descripción de cada tarea y predice su prioridad usando reglas definidas. Se trata de una simulación de un modelo de clasificación automática:

Palabras clave detectadas                     | Prioridad asignada
-----------------------------                 | -------------------
"urgente", "hoy", "ya" "Inmediato" "Rapido"   | Alta (1)
"importante", "mañana" "Pronto" "Despues"     | Media (2)
Cualquier otra                                | Baja (3)

Esta lógica actúa como un clasificador básico que imita un modelo supervisado de ML.

Estructuras de Datos Utilizadas:
- List<T>: Lista de tareas pendientes (simulando una cola FIFO)
- Stack<T>: Historial de tareas completadas (LIFO)
- Dictionary<K,V>: Acceso rápido por título (tabla hash)

## Instrucciones de ejecución

1. Abrir el proyecto en Visual Studio Code
2. 1. Asegúrate de tener el SDK de .NET instalado (dotnet --version)
3. Ejecutar los comandos:    (dotnet build) y luego (dotnet run)
