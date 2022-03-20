using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * with를 이용한 레코드 복사
 * 
 * C# 컴파일러는 레코드 형식을 위한 복사 생성자를 자동으로 작성한다.
 * 단, 이 복사 생성자는 protected로 선언되기 때문에 명시적으로 호출할 수 없고,
 * with 식을 사용해야 된다.
 * 
 * RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
 * RTransaction tr2 = tr1 with {To = "Charlie"};
 */

namespace WithExp
{
    record RTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return string.Format($"{From,-10} -> {To,-10} : ${Amount}");
        }
    }

    class Program
    {
        static void Main()
        {
            RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
            RTransaction tr2 = tr1 with { To = "Charlie" };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
        }
    }
}
