using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 로컬 함수 (Local Function)
 * 
 * 메소드 안에서 선언되고, 선언된 메소드 안에서만 사용되는 특별한 함수
 * 클래스의 멤버가 아니기 때문에 메소드가 아니라 함수(function)라고 부른다.
 * 
 * 로컬 함수는 자신이 존재하는 지역에 선언되어 있는 변수를 사용할 수 있다.
 * 
 * 메소드 밖에서는 다시 쓸 일 없는 반복적인 작업을 하나의 이름 아래 묶어놓는 데 좋다.
 * => 후반에 가서 람다식을 더 자주 사용하게 된다.
 */

namespace ConsoleApp4.Method_6
{
    internal class LocalFunction
    {
        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }

            return new string(arr);
        }

        static void Main()
        {
            Console.WriteLine(ToLowerString("Hello!"));
            Console.WriteLine(ToLowerString("Good Morning"));
            Console.WriteLine(ToLowerString("This is C#."));
        }
    }
}
