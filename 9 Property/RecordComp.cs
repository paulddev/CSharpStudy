using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 레코드 객체 비교하기
 * 
 * 컴파일러는 레코드의 상태를 비교하는 Equals() 메소드를 자동으로 구현한다.
 * 레코드는 참조 형식이지만, 값 형식처럼 Equals() 메소드를 구현하지 않아도 비교가 가능하다.
 */

namespace RecordComp
{
    class CTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return string.Format($"{From,-10} -> {To,-10} : ${Amount}");
        }
    }

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
            CTransaction trA = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };
            CTransaction trB = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };

            Console.WriteLine(trA);
            Console.WriteLine(trB);
            Console.WriteLine(trA.Equals(trB));

            RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
            RTransaction tr2 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine(tr1.Equals(tr2));
        }
    }
}
