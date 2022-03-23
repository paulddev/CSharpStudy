using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Queue
{
    class Program
    {
        static void Main()
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            // FIFO (먼저 들어간 아이템이 먼저 나온다)
            while (q.Count> 0)
                Console.WriteLine(q.Dequeue());
        }
    }
}
