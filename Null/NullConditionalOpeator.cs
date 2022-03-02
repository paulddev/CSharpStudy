using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Null 조건부 연산자
 * 
 * C# 6.0에 도입됬다.
 * 
 * ?. 가 하는 일은 객체의 멤버에 접근하기 전에 객체가 null인지 검사하여 그 결과가 참이면 null을 리턴하고,
 * 그렇지 않은 경우에는 .뒤에 지정된 멤버를 반환한다.
 * 
 * ?[] 도 동일한 기능을 수행하는 연산자다.
 * 객체의 멤버 접근이 아닌 배열과 같은 컬렉션 객체의 첨자를 이용한 참조에 사용된다는 점에서 다르다.
 * 
 */

namespace ConsoleApp4.Null
{
    internal class NullConditionalOpeator
    {
        static void Main()
        {
            // a? 가 null을 반환하므로 아무것도 출력하지 않지만,
            ArrayList a = null;
            a?.Add("야구");
            a?.Add("축구");
            Console.WriteLine(a?.Count);
            Console.WriteLine(a?[0]);
            Console.WriteLine(a?[1]);

            // a? 가 더 이상 null이 아니기 때문에 올바른 출력 결과를 얻을 수 있다.
            a = new ArrayList();
            a?.Add("야구");
            a?.Add("축구");
            Console.WriteLine(a?.Count);
            Console.WriteLine(a?[0]);
            Console.WriteLine(a?[1]);
        }
    }
}
