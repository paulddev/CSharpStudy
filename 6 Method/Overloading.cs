using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 메소드 오버로딩(Overloading)
 * 하나의 메소드 이름에 여러 개의 구현을 올리는 것.
 * -> 오로지 매개변수만 분석한다. 반환 형식은 체크하지 않는다.
 * -> 실행할 메소드의 버전을 찾는 작업이 컴파일 타임에 이루어지므로 성능 저하x
 */

namespace ConsoleApp4.Method_6
{
    internal class Overloading
    {
        static int Plus(int a, int b)
        {
            Console.WriteLine("Call int Plus(int,int)");
            return a + b;
        }
        static int Plus(int a, int b, int c)
        {
            Console.WriteLine("Call int Plus(int,int,int)");
            return a + b + c;
        }
        static double Plus(double a, double b)
        {
            Console.WriteLine("Call int Plus(double,double)");
            return a + b;
        }
        static double Plus(int a, double b)
        {
            Console.WriteLine("Call int Plus(int,double)");
            return a + b;

        }

        static void Main()
        {
            Console.WriteLine(Plus(1, 2));
            Console.WriteLine(Plus(1, 2, 3));
            Console.WriteLine(Plus(1.1, 2.2));
            Console.WriteLine(Plus(1, 2.4));
        }
    }
}
