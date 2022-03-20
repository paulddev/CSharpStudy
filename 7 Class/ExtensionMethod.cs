using System;
using MyExtension; // 확장 메소드를 담는 클래스의 네임스페이스를 사용한다.
/*
 * 확장 메소드(Extension Method)
 * 기존 클래스의 기능을 확장하는 기법이다.
 * string 클래스에 문자열을 뒤집는 기능을 넣거나, int 형식에 제곱 연산 기능을 넣을 수도 있다.
 * 
 * 메소드의 첫 번째 매개변수는 반드시 this 키워드와 함께 확장하고자 하는 클래스의 인스턴스여야 한다.
 * 클래스도 static, 메소드도 static으로 선언해야 한다.
 * 네임명은 되도록이면 Extension을 붙이면 좋다.
 */

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int a)
        {
            return a * a;
        }
        public static int Power(this int a, int exponent)
        {
            int result = a;
            for(int i = 1; i < exponent; i++)
            {
                result *= a;
            }
            return result;
        }
    }
}

namespace ExtensionMethod
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"3^2 : {3.Square()}");
            Console.WriteLine($"3^4 : {MyExtension.IntegerExtension.Power(3, 4)}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            Console.WriteLine($"2^10 : {2.Power(10)}");
        }
    }
}
