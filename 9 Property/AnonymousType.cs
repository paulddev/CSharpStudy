using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 무명 형식 (이름이 없는 형식)
 * => 형식의 선언과 동시에 인스턴스를 할당한다.
 * 무명 형식의 프로퍼티에 할당된 값은 변경불가능 하다.
 * 
 * 무명 형식의 인스턴스가 만들어지고 난 다음에는 읽기만 수행할 수 있다는 뜻.
 * => LINQ에서 유용하다.
 */

namespace AnonymousType
{
    class Program
    {
        static void Main()
        {
            var a = new { Name = "Do", Age = 27 };
            Console.WriteLine($"Name:{a.Name}, Age:{a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };
            Console.Write($"Subject:{b.Subject}, Scores: ");
            foreach(var score in b.Scores)
                Console.Write($"{score} ");

            Console.WriteLine();
        }
    }
}
