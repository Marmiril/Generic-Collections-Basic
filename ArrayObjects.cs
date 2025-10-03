using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenericCollections
{

    /// <summary>
    /// Programa en C# que utiliZA un ArrayList para almacenar una lista de personas.
    /// Clase llamada Persona.cs con dos propiedades (nombre y edad) y un método ToString() para imprimir el resultado.
    /// Define un ArrayList que solicita la información(nombre y edad) de tres personas al usuario, que irá almacenando la información en la lista.
    /// </summary>
    internal class ArrayObjects
    {
        public void Execute()
        {
            ArrayList list = new ArrayList();
            int total = 3;
            
            for (int i = 0; i < total; i++)
            {
                string name = Console.ReadLine() ?? "";
                int age = int.Parse(Console.ReadLine() ?? "");

                list.Add(new Persona()
                {
                    Name = name,
                    Age = age
                });
            }

            foreach (Persona p in list)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public class Persona
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return Name + " - " + Age;
            }
        }
    }
}
