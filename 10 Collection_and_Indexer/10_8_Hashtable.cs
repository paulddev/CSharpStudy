using System;
using System.Collections;

namespace _10_8_Hashtable
{
    public class Program
    {
        static void Main()
        {
            Hashtable ht = new Hashtable();
            ht["one"] = 1;
            ht["two"] = 2;
            ht["three"] = 3;

            Console.WriteLine(ht["one"]);
            Console.WriteLine(ht["two"]);
            Console.WriteLine(ht["three"]);
        }
    }
}
