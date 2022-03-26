using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_garbage
{

    class A { }
    class B { }
    class C { }
    class Program
    {
        static void Main()
        {
            A a = new A();
            B b = new B();
            C c = new C();

            Console.WriteLine(GC.GetGeneration(a)); // 0
            GC.Collect(0); // 모든 세대의 가비지 수집을 즉시 실행

            b = null;

            Console.WriteLine(GC.GetGeneration(a)); // 1
            GC.Collect(0);

            Console.WriteLine(GC.GetGeneration(a)); // 1
            GC.Collect(0);
            A a2 = new A();
        }
    }
}
