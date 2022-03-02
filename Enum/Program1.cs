using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 열거 형식 - 여러 개의 상수를 정리한다.
 * 
 * 열거 형식도 상수이긴 하지만 const 키워드를 사용하지 않으며, enum 키워드로 정의한다.
 * 
 * 열거 형식으로 지정하면 헷갈릴 위험도 적고, 고치기 쉽다(유지 보수가 쉽다)
 */

namespace ConsoleApp4.Enum
{
    class Program
    {
        // 통상적으로 아무 할당도 없다면 zero base부터 시작하며, +1씩 증가한다.
        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }

        static void Main()
        {
            Console.WriteLine((int)DialogResult.YES);      // 0
            Console.WriteLine((int)DialogResult.NO);       // 1
            Console.WriteLine((int)DialogResult.CANCEL);   // 2
            Console.WriteLine((int)DialogResult.CONFIRM);  // 3
            Console.WriteLine(DialogResult.OK);            // OK (내부적으로 ToString())

            DialogResult result = DialogResult.YES;

            Console.WriteLine(result == DialogResult.YES);     // True
            Console.WriteLine(result == DialogResult.NO);      // False
            Console.WriteLine(result == DialogResult.CANCEL);  // False
            Console.WriteLine(result == DialogResult.CONFIRM); // False
            Console.WriteLine(result == DialogResult.OK);      // False


        }
    }
}
