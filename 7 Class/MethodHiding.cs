using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 메소드 숨기기?
 * 
 * CLR에게 기반 클래스에서 구현된 버전의 메소드를 감추고 파생 클래스에서 구현된 버전만 보여주는 것
 * => new 한정자로 수식한다.
 * 
 * 메소드 숨기기는 오버라이딩과 다르다.
 * 이름 그대로 메소드를 숨기고 새롭게 정의한다.
 * 
 * 메소드 숨기기는 완전한 다형성을 표현하지는 못한다.
 * 따라서 기반 클래스를 설계할 때는 파생 클래스의 모습까지 고려해야 한다.
 */

namespace ConsoleApp4.Class_7
{
    class Base
    {
        public void MyMethod()
        {
            Console.WriteLine("Base.MyMethod()");
        }
    }

    class Derived : Base
    {
        public new void MyMethod()
        {
            Console.WriteLine("Derived.MyMethod()");
        }
    }

    class Program
    {
        static void Main()
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            // 이건 결과가 멀까?
            Base derivedObj2 = new Derived();
            derivedObj2.MyMethod();
        }
    }
}
