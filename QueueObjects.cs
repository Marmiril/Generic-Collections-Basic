using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericCollections
{
    public class QueueObjects
    {
        public void Execute()
        {
            
            Console.WriteLine("Tamaño de la cola: ");

            int size;
            while(!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Dato inválido. Inténtelo de nuevo: ");                
            }

            QueueObj queue = new QueueObj(size);

            while (true)
            {
                
                Console.WriteLine(" ==== MENU ====");
                Console.WriteLine("1 - Añadir persona.");
                Console.WriteLine("2 - Sacar persona.");
                Console.WriteLine("3 - Ver listado.");
                Console.WriteLine("ESC - Salir");
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
                        Console.Write("\nNombre:");

                        string name;
                        while (true)
                        {
                            name = Console.ReadLine() ?? "";

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
                                continue;
                            }

                            break;
                        }

                        Console.WriteLine("\nEdad: ");
                        int age;
                        while(!int.TryParse(Console.ReadLine(), out age) || age < 0)
                        {
                            Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
                        }

                        try
                        {
                            queue.Enqueue(new Person { Name = name, Age = age });
                            Console.WriteLine($"Persona añadida:\n {name} - {age}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}.");
                        }                     
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        try
                        {
                            Person p = queue.Dequeue();
                            Console.WriteLine($"\nPersona que sale del listado: {p}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}.");
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        queue.Print();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        continue;
                }
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public int    Age  { get; set; }

            public override string ToString() => $"{Name} - {Age}";
        }

        public class QueueObj
        {
            private Person[] queue;
            private int position;

            public QueueObj(int size)
            {
                position = -1;
                queue = new Person[size];
            }

            public void Enqueue(Person value)
            {
                if (position + 1 >= queue.Length) throw new InvalidOperationException("Cola llena.");
                position++;
                queue[position] = value;
            }

            public Person Dequeue()
            {
                if (position < 0 ) throw new InvalidOperationException("Cola vacía.");

                Person first = queue[0];

                for (int i = 0; i < position; i++)
                    queue[i] = queue[i + 1];

                position--;

                return first;
            }

            public void Print()
            {
                if (position < 0)
                {
                    Console.WriteLine("Cola vacía.");
                    return;
                }

                Console.WriteLine("\nCola actual");
                for (int i = 0; i <= position; i++)
                {
                    Console.WriteLine(queue[i]);
                }
            }
        }
    }
}
