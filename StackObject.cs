using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    internal class StackObject
    {
        public void Execute()
        {
            Console.WriteLine("Indique el tamaño de la pila (3-10): ");
            int size;
            while(!int.TryParse(Console.ReadLine(), out size)|| size < 3 || size > 10)
            {
                Console.WriteLine("Entrada no válida. Inténtelo de nuevo: ");
            }

            StackObj stack = new StackObj(size);

            while (true)
            {
                Console.WriteLine(" ==== MENU ====");
                Console.WriteLine("1 - AÑADIR");
                Console.WriteLine("2 - ELIMINAR");
                Console.WriteLine("3 - CONSULTAR TOP");
                Console.WriteLine("4 - VER PILA.");
                Console.WriteLine("ESC - Salir");

                var key = Console.ReadKey(intercept: false);

                if (key.Key == ConsoleKey.Escape) return;

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        if (stack.IsFull) { Console.WriteLine("La pila está llena. Elimine algún elemento para insertar más."); break; }

                        string name;
                        Console.WriteLine("Nombre: ");
                        while (true)
                        {
                            name = Console.ReadLine() ?? "";
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Nombre no válido. Inténtelo de nuevo.");
                                continue;
                            }
                            else break;
                        }

                        int age;
                        Console.WriteLine("Edad: ");

                        while(!int.TryParse(Console.ReadLine(), out age) || age < 0)
                        {
                            Console.WriteLine("Entrada no válida. Inténtelo de nuevo.");
                        }

                        try
                        {
                            stack.Push(new Persona { Name = name, Age = age });
                            break;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        if (stack.IsEmpty) { Console.WriteLine("La pila está vacía."); break; }
                        
                        try
                        {
                            Persona persona = stack.Pop();
                            Console.WriteLine($"\nSe ha eliminado a {persona} de la pila.");
                        }   
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:                                              

                        if (stack.IsEmpty) { Console.WriteLine("La pila está vacía."); break; }
                        try
                        {
                            Persona top = stack.Peek();
                            Console.WriteLine($"El último elemento de la pila es {top}");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        if (stack.IsEmpty) { Console.WriteLine("La pila está vacía."); break; }
                        try
                        {
                            stack.Print();
                            break;
                        }
                        catch(Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                }
            }
        }

        public class Persona
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString() => $"{Name} - {Age}";
        }


        public class StackObj
        {
            private Persona[] stack;
            private int top;
            public bool IsFull => top >= stack.Length;
            public bool IsEmpty => top == 0;

            public StackObj(int size)
            {
                if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));

                stack = new Persona[size];

                top = 0;
            }

            public void Push(Persona value)
            {
                stack[top] = value;
                top++;
            }

            public Persona Pop()
            {
                if (top == 0) throw new InvalidOperationException("Pila vacía.");
                top--;
                return stack[top];
            }

            public Persona Peek()
            {
                if (top == 0) throw new InvalidOperationException("Pila vacía.");
                return stack[top - 1];
            }

            public void Print()
            {
                for (int i = top - 1; i >= 0; i--)
                {
                    Console.WriteLine($"[{i}] - {stack[i]}");
                }
            }
           
        }
    }
}
