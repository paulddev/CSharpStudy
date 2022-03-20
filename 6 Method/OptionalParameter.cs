using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 선택적 인수(디폴트 매개변수)
 * 
 * 메소드의 매개변수는 기본값을 가질 수 있다.
 * 기본값을 가진 매개변수는 필요에 따라 인수를 할당하거나 할당하지 않을 수 있기 때문에 이를 선택적 인수라고도 부른다.
 * 
 * 선택적 인수는 항상 필수 인수 뒤에 와야 한다.
 */

namespace ConsoleApp4.Method_6
{
    internal class OptionalParameter
    {
        static void PrintProfile(string name, string phone = "")
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }

        static void Main()
        {
            PrintProfile("길동");
            PrintProfile("박사", "010-123-1234");
            PrintProfile(name: "로봇");
            PrintProfile(name: "피자가게", phone: "010-123-4567");
        }
    }
}
