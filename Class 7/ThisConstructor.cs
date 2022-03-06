using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * this() 생성자
 * 
 * this() 는 자기 자신의 생성자를 가리킨다.
 * 다만, 생성자에서만 사용할 수 있다.
 * 
 * 다음과 같은 상황일 때에는 this() 생성자가 유용할수도?
 */

namespace ConsoleApp4.Class_7
{
    class MyClass
    {
        int a, b, c; // 이렇게도 선언이 가능하다.

        public MyClass()
        {
            this.a = 10;
            Console.WriteLine("Call MyClass()");
        }

        public MyClass(int b) : this() // 여기 this() 는 MyClass() 를 호출
        {
            this.b = b;
            Console.WriteLine("Call MyClass(int b)");
        }

        public MyClass(int b, int c) : this(b) // 여기 this(b) 는 MyClass(int b) 를 호출
        {
            this.c = c;
            Console.WriteLine("Call MyClass(int b, int c)");
        }

        public void PrintMemberField()
        {
            Console.WriteLine($"{a}, {b}, {c}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass a = new MyClass();
            a.PrintMemberField();

            MyClass b = new MyClass(100);
            b.PrintMemberField();

            MyClass c = new MyClass(100, 1000);
            c.PrintMemberField();
        }
    }
}
