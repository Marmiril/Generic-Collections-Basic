using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    internal class StackArrays2
    {
        public void Execute()
        {
            Console.WriteLine("Indique el tamaño máximo de la pila (3-5): ");


            int size;
            
            while(!int.TryParse(Console.ReadLine(), out size) || size < 3 || size > 5)
            {
                Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
            }

            StackInt stack = new StackInt(size);

            while (true)
            {
                Console.WriteLine(" ==== OPCIONES ==== ");
                Console.WriteLine("1 - AÑADIR.");
                Console.WriteLine("2 - QUITAR");
                Console.WriteLine("3 - VER TOPE");
                Console.WriteLine("4 - VER PILA");
                Console.WriteLine("ESC - Salir.");
                Console.WriteLine("");

                var key = Console.ReadKey(intercept: false);

                if (key.Key == ConsoleKey.Escape) break;

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        Console.WriteLine("\nNúmero a apilar:");

                        int num;

                        while(!int.TryParse(Console.ReadLine(), out num))
                        {
                            Console.WriteLine("\nEntrada no válida. Inténtelo de nuevo: ");
                        }

                        try
                        {
                            stack.Push(num);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        try
                        {
                            int pop = stack.Pop();
                            Console.WriteLine($"\nSe elimina de la pila el número: {pop}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        try
                        {
                            int top = stack.Peek();
                            Console.WriteLine($"\nEl último elemento de la pila es {top}.");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        try
                        {
                            stack.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("\nEntrada errónea. Inténtelo de nuevo.");
                        break;
                
                }
            }




        }

        /// <summary>
        /// Pila de números enteros basada en un array fijo.
        /// position -> Aquí indica la cantidad de elementos y la posición en donde añadirlos. stack.Lenght = postion - 1.
        /// </summary>
        public class StackInt
        {
            private readonly int[] stack;
            private int position;

            public StackInt(int size)
            {
                if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

                stack = new int[size];

                position = 0;
            }

            public void Push(int value)
            {
                if (position >= stack.Length) throw new InvalidOperationException("Pila llena.");

                stack[position] = value;

                position++;
            }

            public int Pop()
            {
                if (position == 0) throw new InvalidOperationException("Pila vacía");                               

                position--;

                return stack[position];
            }

            public int Peek()
            {
                if (position == 0) throw new InvalidOperationException("Pila vacía");

                return stack[position - 1];
            }

            public void Print()
            {
                if (position == 0) { Console.WriteLine("Pila vacía."); return; }

                Console.WriteLine("\nPila - Tope arriba: ");

                for (int i = position - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i} - {stack[i]}");
                }
            }
        }
    }
}
