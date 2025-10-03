using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    internal class QueueObjCircular
    {
        public void Execute()
        {
            Console.WriteLine("Indique el tamaño máximo de la cola: ");

            int size;

            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Dato inválido. Inténtelo de nuevo.");
            }

            QueueObjCirc queue = new QueueObjCirc(size);

            while(true)
            {
                Console.WriteLine("\n === MENÚ ===");
                Console.WriteLine("1 - Añadir persona.");
                Console.WriteLine("2 - Sacar persona.");
                Console.WriteLine("3 - Mostrar listado.");
                Console.WriteLine("ESC - Salir.");
                Console.WriteLine("Seleccione una opción...");

                var key = Console.ReadKey(intercept: true);

                
                
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        Console.WriteLine("\nNombre: ");

                        string name = "";                        

                        while (true)
                        {
                            name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
                                continue;
                            }
                            break;
                        }

                        int age;

                        Console.WriteLine("\nEdad: ");

                        while(!int.TryParse(Console.ReadLine(), out age) || age < 0)
                        {
                            Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
                        }

                        try
                        {
                            queue.Enqueue(new Person { Name = name, Age = age });
                            Console.WriteLine($"Nueva persona añadida: {name} -- {age}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }

                    break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        try
                        {
                            Person p = queue.Dequeue();
                            Console.WriteLine($"Persona eliminada: {p}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        queue.Print();
                        break;

                    default:
                        Console.WriteLine("\nOpción inválida.");
                        break;
                }
            }

        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString() => $"{Name} - {Age}";
        }

        public class QueueObjCirc
        {
            private Person[] queue;
            private int front;
            private int rear;
            private int count;

            public QueueObjCirc(int size)
            {
                queue = new Person[size];
                front = 0;
                rear = 0;
                count = 0;
            }

            public void Enqueue(Person value)
            {
                if (count == queue.Length) throw new InvalidOperationException("Cola llena.");

                queue[rear] = value;
                rear = (rear + 1) % queue.Length; // Avance circular.
                count++;
            }


            public Person Dequeue()
            {
                if (count == 0) throw new InvalidOperationException("Cola vacía.");

                Person result = queue[front];
                front = (front + 1) % queue.Length; // Avance circular de nuevo.

                count--;

                return result;
            }

            public void Print()
            {
                if (count == 0)
                {
                    Console.WriteLine("\nCola vacía.");
                    return;
                }

                Console.WriteLine("\nCola actual:");

                for (int i = 0; i < count; i++)
                {
                    int index = (front + i) % queue.Length;
                    Console.WriteLine(queue[index]);
                }
            }

        }
    }
}
