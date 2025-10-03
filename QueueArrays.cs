using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    internal class QueueArrays
    {
        public void Execute()
        {
            int size = 2;
            Queue queue = new Queue(size);


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
                position++;
                queue[position] = value;
            }

            public int Dequeue()
            {
                if (position < 0) throw new InvalidOperationException("Empety queue.");
                
                int aux = queue[0];

                for (int i = 0; i < position; i++)
                {
                    queue[i] = queue[i + 1];
                }
                                
                position--;

                return queue[position + 1];

            }
        }
    }
}
