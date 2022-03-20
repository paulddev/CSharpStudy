using System;
using System.Collections;

namespace _10_7_Stack
{
    class Program
    {
        static void Main()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while(stack.Count > 0)
            {
                // 데이터를 꺼내고 지운다.
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
