using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 대리자 : 누군가를 대신해서 일해주는 것
 * 
 * 컴파일 시점이 아닌 프로그램 실행 중에 결정된다.
 * 
 * <선언 방식>
 * 한정자 delegate 반환_형식 대리자_이름 ( 매개변수_목록 );
 * 
 * 대리자는 인스턴스가 아닌 형식(Type)이다.
 * 
 * 1. 대리자를 선언
 * 2. 대리자의 인스턴스를 생성, 인스턴스를 생성할 때 대리자가 참조할 메소드를 인수로 넘긴다.
 * 3. 대리자를 호출한다.
 */

namespace _1_Delegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b) => a + b; // 대리자는 인스턴스 메소드도 참조가능
        public static int Minus(int a, int b) => a - b; // 대리자는 정적 메소드도 참조가능
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            MyDelegate Callback; // 대리자를 선언

            Callback = new MyDelegate(calc.Plus); // 대리자의 인스턴스를 생성하고 참조할 인수를 넘김
            Console.WriteLine(Callback(3, 7));

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(13, 7));
        }
    }
}
