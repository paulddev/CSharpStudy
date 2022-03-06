using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 분할 클래스(Partial Class)
 * 
 * 여러 번에 나눠서 구현하는 클래스
 * 클래스의 구현이 길어질 경우 여러 파일에 나눠서 구현할 수 있게 함으로써 소스 코드 관리의 편의를 제공.
 * 
 * partial 키워드를 이용한다.
 * C# 컴파일러는 분할 구현된 코드를 하나의 MyClass로 묶어 컴파일한다.
 * 
 */

namespace ConsoleApp4.Class_7
{
    partial class MyClass
    {
        public void Method1()
        {
            Console.WriteLine("Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }

    partial class MyClass
    {
        public void Method3()
        {
            Console.WriteLine("Method3");
        }

        public void Method4()
        {
            Console.WriteLine("Method4");
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass obj = new MyClass();
            obj.Method1();
            obj.Method2();
            obj.Method3();
            obj.Method4();
        }
    }
}
