using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 레코드 형식으로 만드는 불변 객체
 * 
 * 불변객체는 내부 상태를 변경할 수 없는 객체를 뜻한다.
 * 상태를 변경할 수 없기 때문에 데이터 복사와 비교가 많이 이뤄진다.
 * 새로운 상태를 표현하려고 기존 상태를 복사한 뒤 이 중 일부를 수정해서 새로운 객체를 만들고,
 * 상태를 확인하기 위해 객체 내용을 자주 비교한다.
 * 
 * Record는 불변 객체에서 빈번하게 이뤄지는 두 가지 연산을 편리하게 수행할 수 있도록 C# 9.0에서 제공한다.
 * 
 * 참조 형식은 클래스의 모든 필드를 readonly로 선언하면 불변 객체를 만들 수 있다.
 * 값 형식은 readonly struct 구조체로 선언하면 된다.
 * 
 * 값 형식은 다른 객체에 할당할 때 깊은 복사를 수행한다. (모든 필드를 새 객체가 가진 필드에 1:1로 복사하는 것을 말한다.)
 * 필드가 많으면 많을수록 복사 비용이 커진다.
 * 다만 참조 형식은 이런 오버헤드가 없다.
 * 
 * 참조 형식끼리 내용 비교를 할 수 있으려면 프로그래머가 직접 구현해야 한다.
 * 보통은 object로부터 상속하는 Equals() 메소드를 오버라이딩 한다.
 * 
 * 레코드 형식은 값 형식처럼 다룰 수 있는 불변 참조 형식으로, 참조 형식의 비용 효율과 값 형식이 주는 편리함을 모두 제공한다.
 */

namespace Record
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
            RTransaction tr2 = new RTransaction { From = "Bob", To = "Charlie", Amount = 50 };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
        }
    }
}
