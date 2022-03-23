using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Stack
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // LIFO (나중에 들어온 아이템이 먼저 나간다)
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }
    }
}
