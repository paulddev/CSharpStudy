using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tuple(튜플)
 * 
 * 여러 필드를 담을 수 있는 구조체
 * 튜플은 이름 형식이 없고, 즉석에서 사용할 복합 데이터 형식을 선언할 때 적합하다.
 * 값 형식이기 때문에 생성된 지역을 벗어나면 스택에서 소멸되기 때문에 프로그램에 장기적인 부담을 주지 않는다.
 * 
 * 컴파일러가 튜플의 모양을 보고 직접 형식을 결정하도록 var 이용하여 선언
 * 튜플은 괄호 사이에 두 개 이상의 필드를 지정함으로써 만들어진다.
 * var tuple = (123, 789);
 * 
 * 필드의 이름을 지정하지 않는 튜플을 명명되지 않은 튜플(Unnamed Tuple)이라고 한다.
 * var tuple = (123, 789);
 * Console.WriteLine($"{tuple.Item1}, {tuple.Item2}");
 * 
 * 필드의 이름을 지정한 튜플을 명명된 튜플(Named Tuple)이라고 한다.
 * var tuple = (Name: "name", Age : 26);
 * Console.WriteLine($"{tuple.Name}, {tuple.Age}");
 * 
 * 튜플 분해하기
 * var tuple = (Name: "name", Age : 27);
 * var (name, age) = tuple;
 * Console.WriteLine($"{name}, {age}");
 * 
 * 튜플을 분해할 때 특정 필드를 무시하고 싶다면 '_' 이용
 * var tuple = (Name: "name", Age : 26);
 * var (name, _) = tuple;
 * Console.WriteLine($"{name}");
 * 
 * var (name2, age2) = ("hi", 31);
 * Console.WriteLine($"{name2}, {age2}");
 * 
 * 명명되지 않은 튜플과 명명된 튜플끼리는 필드의 수와 형식이 같다면 할당이 가능하다.
 */

namespace Tuple
{
    class Program
    {
        static void Main()
        {
            // 명명되지 않은 튜플
            var a = ("슈퍼맨", 999);
            Console.WriteLine($"{a.Item1}, {a.Item2}");

            // 명명된 튜플
            var b = (Name: "배트맨", Age: 111);
            Console.WriteLine($"{b.Name}, {b.Age}");

            // 분해
            var (name, age) = ("슈퍼맨", 999);
            Console.WriteLine($"{name}, {age}");

            // 분해2
            var (name2, age2) = b;
            Console.WriteLine($"{name2}, {age2}");

            // 명명된 튜플 = 명명되지 않은 튜플
            b = a;
            Console.WriteLine($"{b.Name}, {b.Age}");
        }
    }
}
