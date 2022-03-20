using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 상태의 변화를 허용하는 객체를 변경가능(Mutable) 객체라고 한다.
 * 상태의 변화를 허용하지 않는 객체를 변경불가능(Immutable) 객체라고 한다.
 * 
 * 변경불가능 객체의 효용은 멀티 쓰레드 간에 동기화(Synchronization)를 할 필요가 없기 때문에 프로그램 성능 향상이 가능,
 * 버그로 인한 상태(데이터)의 오염을 막을 수 있다.
 * 
 * 구조체는 모든 필드와 프로퍼티의 값을 수정할 수 없는, 변경불가능 구조체로 선언할 수 있다.
 * 그런데, 클래스는 변경불가능으로 선언할 수 없다.
 * 
 * readonly struct 구조체이름
 * {
 * }
 * 
 * readonly를 이용해서 구조체를 선언하면, 컴파일러는 해당 구조체의 모든 필드가 readonly로 선언되도록 강제한다.
 */

namespace ReadonlyStruct
{
    readonly struct RGBColor
    {
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;

        public RGBColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return String.Format($"{R}, {G}, {B}");
        }
    }

    class Program
    {
        static void Main()
        {
            RGBColor Red = new RGBColor(255, 0, 0);
            Console.WriteLine(Red.ToString());
        }
    }
}
