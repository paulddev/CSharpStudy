using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 추상 클래스 : 인터페이스와 클래스 사이
 * 
 * "구현"을 가질 수 있다.
 * 클래스와 달리 인스턴스를 가질 수는 없다.
 * 
 * abstract 한정자와 class 키워드를 이용해서 선언한다.
 * 
 * 인터페이스에서는 모든 메소드가 public,
 * 클래스에서는 한정자를 명시하지 않으면 모든 메소드가 private
 * 
 * 추상 클래스에는 인스턴스를 만들 수 없다는 외에도 추상 메소드를 가질 수 있다.
 * 추상 메소드는 추상 클래스가 한편으로 인터페이스의 역할도 할 수 있게 해주는 장치
 * 
 * 구현을 갖지 못하지만 파생 클래스에서 반드시 구현하도록 강제가 가능하다.
 * 
 * 추상 클래스나 클래스는 그 안에서 선언되는 모든 필드, 메소드, 프로퍼티, 이벤트 모두 접근 한정자를
 * 명시하지 않으면 private
 * 
 * 추상 메소드 역시 abstract 한정자를 이용한다.
 * 
 * 추상 클래스가 또 다른 추상 클래스를 상속하는 경우
 * 상속할 수 있으며, 이 경우에는 자식 추상 클래스는 부모 추상 클래스의 추상 메소드를 구현하지 않아도 된다.
 * 추상 메소드는 인스턴스를 생성할 클래스에서 구현하면 되기 때문(인터페이스랑 거의 유사)
 * => 다른 점 다중 상속x
 * 
 * 추상 클래스는 일반 클래스가 가질 수 있는 구현과 추상 메소드를 가지고 있다.
 * 추상 메소드는 추상 클래스를 사용하는 프로그래머가 그 기능을 반드시 정의하도록 하는 장치
 * => 다른 프로그래머가 파생 클래스를 만들 때 모든 추상 메소드를 구현해야 한다는 사실을 잊어버린다 해도, 컴파일러가 상기 시켜준다.
 */

namespace AbstractClass
{
    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            Console.WriteLine("AbstractBase.PrivateMethodA()");
        }

        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            PrivateMethodA();
        }
    }

    class Program
    {
        static void Main()
        {
            AbstractBase obj = new Derived();
            obj.AbstractMethodA();
            obj.PublicMethodA();

            Derived obj2 = new Derived();
            obj2.AbstractMethodA();
            obj2.PublicMethodA();
        }
    }
}
