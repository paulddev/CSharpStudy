using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 상속!
 * 
 * 파생 클래스는 아무 멤버를 선언하지 않아도, 기반 클래스의 모든 것을 물려 받게 된다.
 * 단, private으로 선언된 멤버는 예외다!
 * 
 * 파생 클래스는 객체를 생성할 때 내부적으로 기반 클래스의 생성자를 호출한 후에 자신의 생성자를 호출하고,
 * 객체가 소멸될 때는 반대의 순서로 [파생 클래스 -> 기반클래스] 순으로 종료자(Finalizer)를 호출한다.
 * 
 * 파생 클래스의 인스턴스를 생성할 때 호출되는 기반 클래스의 생성자에는 어떻게 매개변수를 전달할 수 있을까?
 * => base 키워드를 사용하자.
 * 
 * this 키워드가 "자기 자신"이라면, base 키워드는 "기반 클래스"를 가리킨다.
 * 
 * 의도하지 않은 상속이나 파생 클래스의 구현을 막기 위해서 상속이 불가능하도록 클래스를 선언할 수 있다.
 * => sealed 한정자 키워드를 사용 (상속 봉인!)
 */

namespace ConsoleApp4.Class_7
{
    class Base
    {
        protected string name;
        public Base(string name)
        {
            this.name = name;
            Console.WriteLine($"{this.name}.Base()");
        }

        ~Base()
        {
            Console.WriteLine($"{this.name}.~Base()");
        }

        public void BaseMethod()
        {
            Console.WriteLine($"{name}.BaseMethod()");
        }
    }

    class Derived : Base
    {
        public Derived(string name) : base(name)
        {
            Console.WriteLine($"{this.name}.Derived()");
        }

        ~Derived()
        {
            Console.WriteLine($"{this.name}.~Derived()");
        }

        public void DerivedMethod()
        {
            Console.WriteLine($"{this.name}.DerivedMethod()");
        }
    }

    // 호출되는 순서를 생각하면 도움이 된다.
    class Program
    {
        static void Main()
        {
            Base a = new Base("a");
            a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();
        }
    }
}
