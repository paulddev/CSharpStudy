using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * try ~ catch 문을 이용한 예외 처리 : 실제 일을 하는 코드와 문제를 처리하는 코드를 깔끔하게 분리시킴
 * 
 * StackTrace 프로퍼티를 통해 문제가 발생한 부분의 소스 코드 위치를 알려주기 때문에 디버깅이 아주 용이하다.
 */

namespace _7_StackTrace
{
    class Program
    {
        static void Main()
        {
            try
            {
                int a = 1;
                Console.WriteLine(3 / --a);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
