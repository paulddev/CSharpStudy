using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* out 키워드 (출력 전용 매개변수)
 * 
 * out 에는 ref에 없는 안전장치가 있다.
 * ref 키워드를 이용해서 매개변수를 넘기는 경우 메소드가 해당 매개변수에 결과를 저장하지 않아도 컴파일러는 아무런 경고를 주지 않지만
 * out 키워드를 이용해서 매개변수를 넘길 때는 메소드가 해당 매개변수에 결과를 저장하지 않으면 컴파일러가 에러 메시지를 출력한다.
 * 
 * ref 키워드로 인자를 넘길 때는 반드시 초기화가 필요
 * out 키워드로 인자를 넘길 때는 초기화 필요 없다. -> 호출당하는 메소드에서 그 지역 변수를 할당할 것을 보장하기 때문에
 * 
 */

namespace ConsoleApp4.Method_6
{
    internal class UsingOut
    {
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        static void Main()
        {
            int a = 20;
            int b = 3;

            Divide(a, b, out int c, out int d);

            Console.WriteLine($"a/b:{c}, a%c:{d}");
        }
    }
}
