Descripción

Este repositorio contiene una colección de ejercicios en C# diseñados para practicar estructuras de datos básicas implementadas desde cero: arrays, colas y pilas.
El objetivo es comprender el funcionamiento interno de estas estructuras, sin depender de las colecciones genéricas de .NET, y reforzar la lógica de control con menús interactivos en consola.

Contenido de los ejercicios:
* ArrayObjects.cs
Uso de un ArrayList para almacenar objetos Persona con nombre y edad. Se introducen datos por consola y se muestran en pantalla.

* QueueArrays.cs
Implementación básica de una cola de enteros con array. Incluye métodos Enqueue y Dequeue.

* QueueArrays2.cs
Versión interactiva de la cola de enteros con un menú en consola. Permite al usuario añadir, eliminar y visualizar los elementos.

* QueueObjects.cs
Implementación de una cola de objetos Persona con array y menú interactivo.

* QueueObjCircular.cs
Versión optimizada de la cola de objetos, implementada como cola circular usando índices front, rear y count.

* StackArrays.cs
Implementación básica de una pila de enteros con métodos Push y Pop.

* StackArrays2.cs
Pila de enteros con menú interactivo en consola, incluyendo opciones para añadir, quitar, consultar el tope y mostrar la pila completa.

* StackObject.cs
Implementación de una pila de objetos Persona con validaciones de capacidad (IsFull, IsEmpty) y menú interactivo.

Ejecución:
Cada archivo contiene un método Execute() que se puede invocar desde Program.cs.
En el Program.cs actual, se ejecuta por defecto:

new StackObject().Execute();
Para probar otro ejercicio, basta con reemplazar esta línea.

Objetivo de aprendizaje
- Comprender las operaciones básicas de colas (FIFO) y pilas (LIFO).
- Practicar el control de errores (InvalidOperationException).
- Familiarizarse con el manejo de índices, condiciones de desbordamiento y vaciado.
- Implementar menús en consola con Console.ReadKey.

===================================================================================================================================================================================================================================================
===================================================================================================================================================================================================================================================
===================================================================================================================================================================================================================================================

Description

This repository contains a collection of C# exercises aimed at practicing fundamental data structures implemented from scratch: arrays, queues, and stacks.
The goal is to understand how these structures work internally, without relying on .NET built-in collections, while reinforcing control logic with interactive console menus.

Exercises included:_
* ArrayObjects.cs
Demonstrates the use of an ArrayList to store Person objects (name and age). Data is read from console and displayed back.

* QueueArrays.cs
Basic integer queue implementation using an array, with Enqueue and Dequeue methods.

* QueueArrays2.cs
Interactive version of the integer queue with a console menu. Allows the user to add, remove, and display elements.

* QueueObjects.cs
Implementation of a queue of Person objects using arrays and an interactive console menu.

* QueueObjCircular.cs
Optimized circular queue of Person objects, using front, rear, and count indices.

* StackArrays.cs
Basic integer stack implementation with Push and Pop.

* StackArrays2.cs
Integer stack with interactive console menu, including options to push, pop, peek, and print the full stack.

* StackObject.cs
Implementation of a stack of Person objects, with capacity checks (IsFull, IsEmpty) and interactive menu.

Execution:
Each file provides an Execute() method that can be called from Program.cs.
In the current Program.cs, the executed class is:

new StackObject().Execute();
To run a different exercise, just replace this line.

Learning objectives:
- Understand basic operations of queues (FIFO) and stacks (LIFO).
- Practice exception handling (InvalidOperationException).
- Gain experience with index handling, overflow/underflow checks.
- Implement console menus with Console.ReadKey.
