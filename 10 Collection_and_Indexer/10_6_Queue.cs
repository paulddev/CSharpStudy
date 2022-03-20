using System;
using System.Collections.Generic;
using System.Collections;

namespace _10_5_Queue
{
    class Program
    {
        static void Main()
        {
            Queue que = new Queue();
            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);

            while (que.Count > 0)
            {
                Console.Write($"{que.Dequeue()} ");
            }
        }
    }
}
