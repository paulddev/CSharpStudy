using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 튜플이 분해가 가능한 이유는 분해자(Deconstructor)를 구현하고 있기 때문
 * 
 * 객체를 분해한 결과를 switch 문이나 switch 식의 분기 조건에 활용할 수 있다.
 * 이것을 패턴 매칭(Positional Pattern Matching)이라고 한다.
 */

namespace PositionalPattern
{
    class Program
    {
        private static double GetDiscountRate(object client)
        {
            return client switch
            {
                ("학생", int n) when n < 18 => 0.2, // 학생 & 18세 미만
                ("학생", _) => 0.1,                 // 학생 & 18세 이상
                ("일반", int n) when n < 18 => 0.1, // 일반 & 18세 미만
                ("일반", _) => 0.05,                // 일반 & 18세 이상
                _ => 0,
            };
        }

        static void Main()
        {
            var alice = (job: "학생", age: 17);
            var bob = (job: "학생", age: 23);
            var charlie = (job: "일반", age: 15);
            var dave = (job: "일반", age: 21);

            Console.WriteLine($"alice : {GetDiscountRate(alice)}");
            Console.WriteLine($"bob : {GetDiscountRate(bob)}");
            Console.WriteLine($"charlie : {GetDiscountRate(charlie)}");
            Console.WriteLine($"dave : {GetDiscountRate(dave)}");
        }
    }
}
