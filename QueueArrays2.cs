using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericCollections
{
    internal class QueueArrays2
    {
        public void Execute()
        {
            Console.WriteLine("Indique el tamaño máximo de la cola: ");

            int size;

            while(!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Dato inválido. Inténtelo de nuevo: ");
            }

            Queue queue = new Queue(size);

            while (true)
            {
                Console.WriteLine(" ==== MENU ==== ");
                Console.WriteLine("1 - Añadir a la cola.");
                Console.WriteLine("2 - Sacar de la cola.");
                Console.WriteLine("3 - Ver la cola.");
                Console.WriteLine("ESC - Salir");
                Console.WriteLine("Seleccione una opción...");

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Escape) break;

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Indique un número: ");

                        if (int.TryParse(Console.ReadLine(), out int val))
                        {
                            try
                            {
                                queue.Enqueue(val);
                                Console.WriteLine($"Se ha intoducido el valor '{val}' en cola.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error inesperado: {ex.Message}.");
                            }
                        }
                        else Console.WriteLine("Entrada inválida.");
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        try
                        {
                            int result = queue.Dequeue();
                            Console.WriteLine($"Se ha sacado de cola el valor '{result}'.");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine();
                        queue.Print();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;

                }
            }
        }
    }

    public class Queue
    {
        private int[] queue;
        private int position;

        public Queue(int size)
        {
            position = -1;
            queue = new int[size];
        }

        public void Enqueue(int value)
        {
            if (position + 1 >= queue.Length) throw new InvalidOperationException("Cola llena");

            position++;
                queue[position] = value;
            
        }

        public int Dequeue()
        {
            if (position < 0) throw new InvalidOperationException("Cola vacía");

            int first = queue[0];
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

            Console.WriteLine("Cola actual: ");

            for (int i = 0; i < position; i++)
            {
                Console.Write(queue[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
