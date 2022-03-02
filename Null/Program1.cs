using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Nullable 형식
 * 
 * 어떤 값도 가지지 않는 변수가 가끔 필요할 때가 있다.
 * 0이 아닌 비어 있는 수 => null
 * 
 * 객체를 참조하는 변수는 null 을 가질 수 있다. ex) Monster class
 * 그러나 int, struct 같은 기본 자료형 변수는 null 을 가질 수 없기 때문에 C#에서는 값이 없다는 것을 표현할 수 있도록 Nullable을 지원한다.
 * 
 * Null + able => Nullable(비어 있는 상태가 될 수 있는 형식)
 * 
 * 데이터형식? 변수이름;
 * int? a = null;
 * float? b = null;
 * double? c = null;
 * 
 * HasValue - 해당 변수가 값을 갖고 있는지 또는 그렇지 않는지
 *            값이 있는 경우 true, 없는 경우 false
 * 
 * Value - 변수에 담겨 있는 값을 나타낸다.
 *         값이 있는 경우 할당된 값, 없는 경우 System.InvalidOperationException 발생
 *         Value를 접근할 때에는 HasValue로 체크 한 후에 접근하기(프로세스가 죽을 위험이 있다)
 *         
 * GetValueOrDefault() - 값이 있는 경우 할당된 값을 리턴, 없는 경우 기존 타입의 default 값을 리턴
 */

namespace ConsoleApp4.Nullable
{
    class Monster
    {
        public int ID { get; set; } = 123;
        public int HP { get; set; } = 50;
    }
    class Program
    {
        static void Main()
        {
            int? a = null;

            Console.WriteLine(a.HasValue); // False
            Console.WriteLine(a != null);  // False
            //Console.WriteLine(a.Value);  // System.InvalidOperationException

            a = 3;

            Console.WriteLine(a.HasValue); // True
            Console.WriteLine(a != null);  // True
            Console.WriteLine(a.Value);    // 3

            // Value 를 사용할 때에는 주의해서 해야 한다.
            // 해당 변수가 null이라면 System.InvalidOperationException을 발생하기 때문

            int result;
            // 1.
            if (a != null)
            {
                result = a.Value;
                Console.WriteLine(result);
            }

            // 2.
            if (a.HasValue)
            {
                result = a.Value;
                Console.WriteLine(result);
            }

            // 3.
            // A ?? B
            // 변수 A가 null이라면 우측 값을 리턴하고,
            // null이 아니라면 a.Value 를 리턴한다.
            result = a ?? 0;
            Console.WriteLine(result);

            // 4.
            // Class의 경우
            Monster monster = null;
            // monster가 null 이면 null 리턴
            // monster가 null이 아니면 ID를 리턴
            int? monster_id = monster?.ID;
            Console.WriteLine(monster_id);

            monster = new Monster();
            int? monster_hp = monster?.HP;
            Console.WriteLine(monster_hp);
        }
    }
}
