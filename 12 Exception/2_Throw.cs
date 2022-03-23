using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * System.Exception 클래스 : 모든 예외의 조상
 * 예외 상황에 따라 섬세한 예외 처리가 필요한 코드는 Exception 만으로는 대응하기 어렵다.
 * => 프로그래머가 발생할 것으로 계산한 예외 말고도 다른 예외까지 받아낼 수 있기 때문에
 *    만약 그 예외가 현재 코드가 아닌 상위 코드에서 처리해야 할 예외라면, 이 코드는 예외 대신 버그를 만드는 셈이기 때문에
 *    따라서, 처리하지 않아야 할 예외까지 처리하는 일이 없도록 작성해야 한다.   
 * 
 * 예외 던지기
 * try ~ catch 예외를 받는다는 것은 어디선가 예외를 던진다는 이야기
 */

namespace _2_Throw
{
    class Program
    {
        static void DoSomething(int arg)
        {
            if (arg < 10)
                Console.WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 크다.");
        }
        static void Main()
        {
            try
            {
                DoSomething(1);
                DoSomething(3);
                DoSomething(5);
                DoSomething(9);
                DoSomething(11);
                DoSomething(13); // 바로 위에서 예외 발생하여 해당 코드는 실행되지 않는다.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
