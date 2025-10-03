using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    internal class StackArrays
    {
        public void Execute()
        {
            int size = 2;

            Stack stack = new Stack(size);

            int val1 = 7;
            int val2 = 1;

            stack.Push(val1);
            stack.Push(val2);

            val1 = stack.Pop();
            val2 = stack.Pop();

            Console.WriteLine(val1);
            Console.WriteLine(val2);

        }

        public class Stack
        {
            private int[] stack;
            private int position;

            public Stack(int size)
            {
                position = 0;
                stack = new int[size];
            }

            public void Push(int value)
            {
                stack[position] = value;
                position++;
            }

            public int Pop()
            {
                if (position > 0)
                {
                    position -= 1;
                    return stack[position];
                }
                return 0;
            }

        }
    }
}
