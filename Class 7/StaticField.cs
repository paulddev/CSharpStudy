using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 정적 필드와 메소드
 * 
 * static은 메소드나 필드가 클래스의 인스턴스가 아닌 클래스 자체에 소속되도록 지정하는 한정자다.
 * 
 * 한 프로그램 안에서 인스턴스는 여러 개 존재할 수 있으나, 클래스는 단 하나만 존재한다. => 유일(unique)
 * 
 * static으로 한정하지 않은 필드는 자동으로 인스턴스에 소속되며, static으로 한정된 필드는 클래스에 소속된다.
 * => 인스턴스를 만들지 않고 클래스의 이름을 통해 필드에 직접 접근이 가능하다.
 * 
 * 프로그램 전체에 걸쳐 공유해야 하는 변수가 있다면 정적 필드를 이용하면 된다.
 * 
 * 정적 메소드 역시 정적 필드처럼 인스턴스가 아닌 클래스 자체에 소속된다.
 * 정적 메소드가 클래스의 인스턴스를 생성하지 않아도 호출이 가능한 메소드라는 점을 기억하자.
 * 
 * 보통 객체 내부의 데이터를 이용해야하는 경우에는 인스턴스 메소드를 사용하고,
 * 내부 데이터를 이용할 일이 없는 경우에는 별도의 인스턴스 생성없이 호출할 수 있도록 메소드를 정적으로 선언한다.
 */

namespace ConsoleApp4.Class_7
{
    class Global
    {
        public static int Count = 0;

        public static void MyName()
        {
            Console.WriteLine("Global!!");
        }
    }

    class A
    {
        public A()
        {
            Global.Count++;
        }
    }

    class B
    {
        public B()
        {
            Global.Count++;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Global.Count : {Global.Count}");

            new A();
            new A();
            new B();
            new B();

            Console.WriteLine($"Global.Count : {Global.Count}");

            Global.MyName();
        }
    }
}
