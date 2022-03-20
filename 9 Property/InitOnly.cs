using System;
/*
 * 초기화 전용(Init-Only) 자동 구현 프로퍼티
 * 
 * C#에서는 데이터 오염을 방지할 수 있는 장치가 여럿 있다.
 * 
 * 접근 한정자, readonly 필드, readonly 구조체, 튜플 등
 * 
 * C# 9.0에서는 읽기 전용 프로퍼티를 아주 간편하게 선언할 수 있도록 개선되었다.
 * 바로 init 접근자 (초기화 이후에 발생하는 프로퍼티 수정을 허용하지 않는다.)
 * 
 * init 접근자는 set 접근자처럼 외부에서 프로퍼티를 변경할 수 있지만,
 * 객체 초기화를 할 때만 프로퍼티 변경이 가능하다는 점이다.
 * 
 * init 접근자를 명시하여 선언한 프로퍼티를 "초기화 전용 자동 구현 프로퍼티" 라고 한다.
 * 
 * 초기화 한 차례 이루어진 후 변경되면 안되는 데이터 예시)
 * 성적표, 금융 거래 기록, 주민번호 등등
 */

namespace InitOnly
{
    class Transaction
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
            Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100 };
            Transaction tr2 = new Transaction { From = "Bob", To = "Charlie", Amount = 50 };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
        }
    }
}
