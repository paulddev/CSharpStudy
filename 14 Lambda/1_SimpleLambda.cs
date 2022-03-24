using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_SimpleLambda
{
    class Program
    {
        delegate int Calculate(int a, int b);

        static void Main()
        {
            Calculate calc = (a, b) => a + b;

            Console.WriteLine($"{3} + {4} : {calc(3,4)}");
        }
    }
}
