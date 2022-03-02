using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 명명된 인수(Named Argument) - 메소드를 호출할 때 이름에 근거해서 데이터를 할당할 수 있는 기능
 * 
 * 인수의 이름 뒤에 콜론(:)을 붙인 뒤 그 뒤에 할당할 데이터를 넣어주면 된다.
 * 
 * 명명된 인수를 이용해서 코드를 작성하면 코드가 훨씬 읽기 좋아진다.
 */

namespace ConsoleApp4.Method_6
{
    internal class NamedParameter
    {
        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }

        static void Main()
        {
            PrintProfile(name: "박찬호", phone: "010-123-1234");
            PrintProfile(phone: "010-123-1234", name: "박찬호");
            PrintProfile("박찬호", "010-123-1234");
            PrintProfile("010-123-1234", "박찬호");
        }
    }
}
