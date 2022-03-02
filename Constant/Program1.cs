using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 상수 Constant - 난 언제나 변하지 않는다.
 * -> 변경하려고 하면 컴파일러가 에러 메시지를 던진다.
 * 
 * const 키워드를 사용해서 선언한다.
 * 
 * 하지만, 상수의 개수가 수백 개로 증가하게 된다면?
 * 서로 다른 의미를 내포하지만 중복된 값을 갖는 상수라면 재앙이 올 수 있다. (의도치 않은 동작)
 */

namespace ConsoleApp4.Constant
{
    class Program
    {
        static void Main()
        {
            const int MAX_INT =  2147483647;
            const int MIN_INT = -2147483648;

            Console.WriteLine(MAX_INT);
            Console.WriteLine(MIN_INT);
        }
    }
}
