using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Var - 데이터 형식을 알아서 파악하는 똑똑한 C# 컴파일러
 * 
 * C#은 변수나 상수에 대해 깐깐하게 형식 검사를 하는 강력한 형식의 언어다.
 * 핵심은 프로그래머의 실수를 줄여준다.
 * 
 * 단, var 키워드를 이용해서 변수를 선언하려면, 반드시 선언과 동시에 초기화를 해줘야 한다.
 * 단, 지역변수로만 사용할 수 있다.
 * -> 필드를 선언하면 컴파일러가 무슨 형식인지 파악할 길이 없기 때문이다.
 * 
 * object 형식으로부터 물려받아 갖고 있는 메소드들
 * GetType() 메소드  - 실제 형식을 알려준다
 * ToString() 메소드 - 변수의 데이터를 문자열로 표시하는 기능
 */

namespace ConsoleApp4.UsingVar
{
    internal class Program1
    {
        static void Main()
        {
            var a = 20;
            Console.WriteLine("Type: {0}, Value: {1}", a.GetType(), a); // Type: System.Int32, Value: 20

            var b = 3.1414213;
            Console.WriteLine("Type: {0}, Value: {1}", b.GetType(), b); // Type: System.Double, Value: 3.1414213

            var c = "Hello, World!";
            Console.WriteLine("Type: {0}, Value: {1}", c.GetType(), c); // Type: System.String, Value: Hello, World!

            var d = new int[] { 1, 2, 3 };
            Console.WriteLine("Type: {0}, Value: {1}", d.GetType(), d); // Type: System.Int32[], Value: System.Int32[]
            foreach (var e in d)
                Console.Write("{0} ", e);

            Console.WriteLine();
        }
    }
}
