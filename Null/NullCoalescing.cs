using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Null 병합 연산자
 * 
 * null 조건부 연산자처럼 프로그램에서 종종 필요한 변수/객체의 null 검사를 간결하게 만들어주는 역할
 * 
 * ?? 연산자는 두 개의 피연산자를 받아들이고 왼쪽 피연산자가 null인지 평가한다.
 * 왼쪽 피연산자가 null이라면 오른쪽 피연산자를 리턴하고, 아니라면 왼쪽 피연산자를 리턴한다.
 * 
 * TryParse() vs Parse()
 * 
 * - Parse() 메소드는 변환이 실패하면 예외를 던진다.
 *           예외가 던져지면 프로그램은 현재 코드의 실행을 멈추고 흐름을 다른 곳으로 이동한다.
 * 
 * - TryParse() 메소드는 변환의 성공 여부를 반환하기 때문에 현재의 코드 흐름을 유지할 수 있다.
 */

namespace ConsoleApp4.Null
{
    internal class NullCoalescing
    {
        static void Main()
        {
            int? num = null;
            Console.WriteLine(num ?? 0);

            num = 99;
            Console.WriteLine(num ?? 0);

            string str = null;
            Console.WriteLine(str ?? "Default");

            str = "I Love Game";
            Console.WriteLine(str ?? "Default");
        }
    }
}
